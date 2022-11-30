using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(ApplicationUser user);

        Task UpdateUserAsync(ApplicationUser user);

        Task DeleteUserAsync(Guid id);

        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();

        Task<IEnumerable<ApplicationUser>> GetUserByNameAsync(string name);

        Task<ApplicationUser> GetUserById(Guid id);

        Task<ApplicationUser> GetUserByEmailAsync(string email);
    }
}
