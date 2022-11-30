using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using DAL.Logger;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public Log Log { get; set; }

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;

            Log = new();
        }

        public async Task CreateUserAsync(ApplicationUser user)
        {
            try
            {
                await _context.Users.AddAsync(user);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível cadastrar o usuário {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            try
            {
                var users = await _context.Users.AsNoTracking().ToListAsync();

                if (users != null)
                    return users;

                return Enumerable.Empty<ApplicationUser>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar  todos os usuários {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetUserById(Guid id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));

                if (user != null)
                    return user;

                return new ApplicationUser();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar o usuário {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public Task<IEnumerable<ApplicationUser>> GetUserByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
