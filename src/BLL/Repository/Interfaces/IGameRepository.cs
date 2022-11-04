using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();

        Task<Game> GetByIdAsync(Guid id);

        Task<Game> GetByNameAsync(string name);
    }
}
