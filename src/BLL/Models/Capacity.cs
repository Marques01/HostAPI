using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class Capacity
    {
        private Guid
            _capacityId = default;

        private int
            _slots = default;

        public Guid CapacityId { get => _capacityId; set=> _capacityId = value; }

        public int Slots { get => _slots; set => _slots = value; }

        public ICollection<GameCapacity> GamesCapacities { get; set; }

        public Capacity()
        {
            _capacityId = Guid.NewGuid();

            GamesCapacities = new Collection<GameCapacity>();
        }
    }
}
