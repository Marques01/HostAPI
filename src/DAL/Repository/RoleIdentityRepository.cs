using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using DAL.Logger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class RoleIdentityRepository : IRoleIdentityRepository
    {
        private ApplicationDbContext _context;

        public Log Log { get; set; }

        public RoleIdentityRepository(ApplicationDbContext context)
        {
            _context = context;

            Log = new();
        }

        public async Task CreateAsync(ApplicationRole applicationRole)
        {
            try
            {
                await _context.Roles.AddAsync(applicationRole);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível criar uma role {ex.Message}";

                Console.WriteLine(errorMessage);

                await Log.Create(errorMessage, this.GetType().ToString());
            }
        }

        public async Task DeleteAsync(ApplicationRole applicationRole)
        {
            try
            {
                _context.Roles.Remove(applicationRole);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível remover a role {ex.Message}";

                Console.WriteLine(errorMessage);

                await Log.Create(errorMessage, this.GetType().ToString());
            }
        }        

        public async Task<IEnumerable<ApplicationRole>> GetAllRolesAsync()
        {
            try
            {
                var roles = await _context.Roles.AsNoTracking().OrderBy(x => x.Name).ToListAsync();

                if (roles != null)
                    return roles;

                return Enumerable.Empty<ApplicationRole>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar todas as roles {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<IdentityUserRole<Guid>>> GetAllUserRolesAsync(Guid id)
        {
            try
            {
                var userRoles = await _context.UserRoles.AsNoTracking().Where(x => x.UserId.Equals(id)).ToListAsync();

                if (userRoles != null)
                    return userRoles;

                return Enumerable.Empty<IdentityUserRole<Guid>>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não buscar a role pelo id {ex.Message}";                

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(ex.Message);
            }
        }

        public async Task<ApplicationRole> GetRoleByIdAsync(Guid id)
        {
            try
            {
                var role = await _context.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

                if (role != null)
                    return role;

                return new ApplicationRole();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não buscar a role pelo id {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(ex.Message);
            }
        }

        public async Task AssociateUserRole(IdentityUserRole<Guid> identityUserRole)
        {
            try
            {
                var role = await GetRoleByIdAsync(identityUserRole.RoleId);

                var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(identityUserRole.UserId));                

                if (string.IsNullOrEmpty(role.Name)) throw new Exception("Role não encontrada");

                if (user is null) throw new Exception("Usuário não encontrado");                

                await _context.UserRoles.AddAsync(identityUserRole);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível associar a role ao usuário {ex.Message}";                

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }
    }
}
