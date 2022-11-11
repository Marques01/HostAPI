using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface IHostCapacityRepository
    {
        Task CreateAsync(HostCapacity hostCapacity);

        Task UpdateAsync(HostCapacity hostCapacity);

        Task DeleteAsync(HostCapacity hostCapacity);

        Task<HostCapacity> GetByIdAsync(int id);

        Task<HostCapacity> GetByGameCapacityId(int id);

        Task<IEnumerable<HostCapacity>> GetAllHostCapacitiesAsync();
    }
}
