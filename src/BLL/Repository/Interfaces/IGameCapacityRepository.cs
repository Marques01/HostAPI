using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface IGameCapacityRepository
    {
        Task CreateAsync(GameCapacity gameCapacity);

        Task UpdateAsync(GameCapacity gameCapacity);

        Task DeleteAsync(GameCapacity gameCapacity);

        Task<GameCapacity> GetByIdAsync(int id);

        Task<IEnumerable<GameCapacity>> GetAllGameCapacitiesAsync();

        Task<IEnumerable<GameCapacity>> GetByGameIdAsync(int id);

        Task<IEnumerable<GameCapacity>> GetByCapacityAsync(int id);
    }
}
