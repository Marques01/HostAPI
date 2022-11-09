using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using DAL.Logger;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class GameCapacityRepository : IGameCapacityRepository
    {
        private ApplicationDbContext _context;

        public Log Log { get; set; }
        public GameCapacityRepository(ApplicationDbContext context)
        {
            _context = context;

            Log = new();
        }

        public async Task CreateAsync(GameCapacity gameCapacity)
        {
            try
            {
                await _context.GamesCapacities.AddAsync(gameCapacity);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possivel incluir a capacidade de slot do game {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task DeleteAsync(GameCapacity gameCapacity)
        {
            try
            {
                _context.GamesCapacities.Remove(gameCapacity);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possivel remover a capacidade de slot do game {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<IEnumerable<GameCapacity>> GetAllGameCapacitiesAsync()
        {
            try
            {
                var gameCapacities = await _context.GamesCapacities.AsNoTracking().ToListAsync();

                if (gameCapacities != null)
                    return gameCapacities;

                return Enumerable.Empty<GameCapacity>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar todos os slots dos games {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<IEnumerable<GameCapacity>> GetByCapacityAsync(Guid id)
        {
            try
            {
                var gameCapacities = await _context.GamesCapacities.AsNoTracking().Where(x => x.CapacityId.Equals(id)).ToListAsync();

                if (gameCapacities != null)
                    return gameCapacities;

                return Enumerable.Empty<GameCapacity>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi buscar os games pela capacidade {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

               throw new Exception(errorMessage);
            }
        }

        public async Task<IEnumerable<GameCapacity>> GetByGameIdAsync(Guid id)
        {
            try
            {
                var gameCapacities = await _context.GamesCapacities.AsNoTracking().Where(x => x.GameId.Equals(id)).ToListAsync();

                if (gameCapacities != null)
                    return gameCapacities;

                return Enumerable.Empty<GameCapacity>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi buscar as capacidades pelo game {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<GameCapacity> GetByIdAsync(Guid id)
        {
            try
            {
                var gameCapacities = await _context.GamesCapacities.AsNoTracking().FirstOrDefaultAsync(x => x.GameCapacityId.Equals(id));

                if (gameCapacities != null)
                    return gameCapacities;

                return new GameCapacity();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi buscar pelo id {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task UpdateAsync(GameCapacity gameCapacity)
        {
            try
            {
                _context.GamesCapacities.Update(gameCapacity);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possivel atualizar a capacidade de slot do game {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }
    }
}
