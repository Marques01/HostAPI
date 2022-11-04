using BLL.Models;
using BLL.Repository.Interfaces;

namespace DAL.Repository
{
    public class CapacityRepository : ICapacityRepository
    {
        public Task<IEnumerable<Capacity>> GetAllCapacitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Capacity> GetBydIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Capacity> GetBySlotsAsync(int slots)
        {
            throw new NotImplementedException();
        }
    }
}
