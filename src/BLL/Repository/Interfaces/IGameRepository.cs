using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface IGameRepository
    {
        Task CreateAsync(Game game);

        Task UpdateAsync(Game game);

        Task DeleteAsync(Game game);

        Task<IEnumerable<Game>> GetAllGamesAsync();

        Task<Game> GetByIdAsync(Guid id);

        Task<Game> GetByNameAsync(string name);
    }
}
