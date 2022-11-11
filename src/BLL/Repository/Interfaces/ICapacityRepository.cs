using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface ICapacityRepository
    {
        Task CreateAsync(Capacity capacity);

        Task UpdateAsync(Capacity capacity);

        Task DeleteAsync(Capacity capacity);

        Task<IEnumerable<Capacity>> GetAllCapacitiesAsync();

        Task<IEnumerable<Capacity>> GetBySlotsAsync(int slots);

        Task<Capacity> GetBydIdAsync(int id);
    }
}
