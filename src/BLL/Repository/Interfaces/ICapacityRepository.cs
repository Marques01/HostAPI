using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface ICapacityRepository
    {
        Task<IEnumerable<Capacity>> GetAllCapacitiesAsync();

        Task<Capacity> GetBySlotsAsync(int slots);

        Task<Capacity> GetBydIdAsync(Guid id);
    }
}
