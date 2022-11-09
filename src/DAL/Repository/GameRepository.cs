using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using DAL.Logger;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class GameRepository : IGameRepository
    {
        private ApplicationDbContext _context;

        public Log Log { get; set; }

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;

            Log = new();
        }

        public async Task CreateAsync(Game game)
        {
            try
            {
                await _context.Games.AddAsync(game);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível cadastrar o game {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task DeleteAsync(Game game)
        {
            try
            {
                _context.Games.Remove(game);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível remover o game {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            try
            {
                var games = await _context.Games.AsNoTracking().OrderBy(x => x.Name).ToListAsync();

                if (games != null)
                    return games;

                return Enumerable.Empty<Game>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar todos os game {ex.Message}\n";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<Game> GetByIdAsync(Guid id)
        {
            try
            {
                var game = await _context.Games.AsNoTracking().FirstOrDefaultAsync(x => x.GameId.Equals(id));

                if (game != null)
                    return game;

                return new Game();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar o game pelo id {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<Game> GetByNameAsync(string name)
        {
            try
            {
                var game = await _context.Games.AsNoTracking().FirstOrDefaultAsync(x => x.Name.Contains(name));

                if (game != null)
                    return game;
                    
                return new Game();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar o game pelo nome {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task UpdateAsync(Game game)
        {
            try
            {
                _context.Games.Update(game);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível atualizar o game {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }
    }
}
