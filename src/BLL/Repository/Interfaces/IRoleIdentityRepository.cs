using BLL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.Repository.Interfaces
{
    public interface IRoleIdentityRepository
    {
        Task CreateAsync(ApplicationRole applicationRole);

        Task DeleteAsync(ApplicationRole applicationRole);

        Task<IEnumerable<ApplicationRole>> GetAllRolesAsync();

        Task<IEnumerable<IdentityUserRole<Guid>>> GetAllUserRolesAsync(Guid id);

        Task<ApplicationRole> GetRoleByIdAsync(Guid id);

        Task AssociateUserRole(IdentityUserRole<Guid> identityUserRole);
    }
}
