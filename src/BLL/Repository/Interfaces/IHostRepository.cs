using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface IHostRepository
    {
        Task<Host> GetByIdAsync(Guid id);

        Task<Host> GetByNameAsync(string name);

        Task<Host> GetByStatusAsync(bool situation);

        Task<Host> GetByDoorAsync(int door);

        Task<IEnumerable<Host>> GetAllHostsAsync();

        Task DisableHostAsync(Host host);

        Task CreateHostAsync(Host host);

        Task DeleteHostAsync(Host host);

        Task Update(Host host);
    }
}
