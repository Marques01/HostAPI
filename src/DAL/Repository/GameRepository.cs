using BLL.Models;
using BLL.Repository.Interfaces;

namespace DAL.Repository
{
    public class GameRepository : IGameRepository
    {
        public Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
