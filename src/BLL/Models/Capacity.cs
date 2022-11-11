using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class Capacity
    {
        private int
            _capacityId = default;

        private int
            _slots = default;

        public int CapacityId { get => _capacityId; set=> _capacityId = value; }

        public int Slots { get => _slots; set => _slots = value; }

        public ICollection<GameCapacity> GamesCapacities { get; set; }

        public Capacity()
        {   
            GamesCapacities = new Collection<GameCapacity>();
        }
    }
}
