using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class GameCapacity
    {
        private int
            _gameCapacityId = default,
            _gameId = default,
            _capacityId = default;

        public int GameCapacityId { get => _gameCapacityId; set => _gameCapacityId = value; }

        public int GameId { get => _gameId; set => _gameId = value; }

        public int CapacityId { get => _capacityId; set => _capacityId = value; }
        
        public Game? Game { get; set; }

        public Capacity? Capacity { get; set; }

        public ICollection<HostCapacity> HostCapacities { get; set; }

        public GameCapacity()
        {
            HostCapacities = new Collection<HostCapacity>();
        }
    }
}
