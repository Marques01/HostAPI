using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using DAL.Logger;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class HostCapacityRepository : IHostCapacityRepository
    {
        private ApplicationDbContext _context;

        public Log Log { get; set; }

        public HostCapacityRepository(ApplicationDbContext context)
        {
            Log = new();

            _context = context;
        }

        public async Task CreateAsync(HostCapacity hostCapacity)
        {
            try
            {
                await _context.HostCapacities.AddAsync(hostCapacity);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível vincular o servidor a um game e capacidade {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task DeleteAsync(HostCapacity hostCapacity)
        {
            try
            {
                _context.HostCapacities.Remove(hostCapacity);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível desvincular o servidor a uma capacidade e game {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<IEnumerable<HostCapacity>> GetAllHostCapacitiesAsync()
        {
            try
            {
                var hostCapacities = await _context.HostCapacities.AsNoTracking().ToListAsync();

                if (hostCapacities != null)
                    return hostCapacities;

                return Enumerable.Empty<HostCapacity>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar as associações dos servidores {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<HostCapacity> GetByGameCapacityId(int id)
        {
            try
            {
                var hostCapacity = await _context.HostCapacities
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.GameCapacityId.Equals(id));

                if (hostCapacity != null)
                    return hostCapacity;

                return new HostCapacity();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar a associação do servidor pelo GameId {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<HostCapacity> GetByIdAsync(int id)
        {
            try
            {
                var hostCapacity = await _context.HostCapacities
                    .AsNoTracking()                    
                    .FirstOrDefaultAsync(x => x.HostCapacityId.Equals(id));

                if (hostCapacity != null)
                    return hostCapacity;

                return new HostCapacity();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar a associação do servidor pelo Id {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task UpdateAsync(HostCapacity hostCapacity)
        {
            try
            {
                _context.HostCapacities.Update(hostCapacity);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível atualizar o servidor a um game e capacidade {ex.Message}";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }
    }
}
