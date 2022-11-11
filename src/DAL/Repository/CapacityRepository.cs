using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using DAL.Logger;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CapacityRepository : ICapacityRepository
    {
        private ApplicationDbContext _context;

        public Log Log { get; set; }

        public CapacityRepository(ApplicationDbContext context)
        {
            _context = context;

            Log = new();
        }

        public async Task CreateAsync(Capacity capacity)
        {
            try
            {
                await _context.Capacities.AddAsync(capacity);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível cadastrar a capacidade {ex.Message}\n";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task DeleteAsync(Capacity capacity)
        {
            try
            {
                _context.Capacities.Remove(capacity);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível remover a capacidade {ex.Message}\n";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<IEnumerable<Capacity>> GetAllCapacitiesAsync()
        {
            try
            {
                var capacities = await _context.Capacities.AsNoTracking().OrderBy(x => x.Slots).ToListAsync();

                if (capacities != null)
                    return capacities;

                return Enumerable.Empty<Capacity>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar todas as capacidades {ex.Message}\n";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<Capacity> GetBydIdAsync(int id)
        {
            try
            {
                var capacity = await _context.Capacities.AsNoTracking().FirstOrDefaultAsync(x => x.CapacityId.Equals(id));

                if (capacity != null)
                    return capacity;

                return new Capacity();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar a capacidade pelo id {ex.Message}\n";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task<IEnumerable<Capacity>> GetBySlotsAsync(int slots)
        {
            try
            {
                var capacities = await _context.Capacities.AsNoTracking().ToListAsync();

                if (capacities != null)
                    return capacities;

                return Enumerable.Empty<Capacity>();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível buscar as capacidades pelo slot {ex.Message}\n";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }

        public async Task UpdateAsync(Capacity capacity)
        {
            try
            {
                _context.Capacities.Update(capacity);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Não foi possível atualizar a capacidade {ex.Message}\n";

                await Log.Create(errorMessage, this.GetType().ToString());

                throw new Exception(errorMessage);
            }
        }
    }
}
