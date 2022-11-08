using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class GameCapacity
    {
        private Guid
            _gameCapacityId = default,
            _gameId = default,
            _capacityId = default;

        public Guid GameCapacityId { get => _gameCapacityId; set => _gameCapacityId = value; }

        public Guid GameId { get => _gameId; set => _gameId = value; }

        public Guid CapacityId { get => _capacityId; set => _capacityId = value; }
        
        public Game Game { get; set; }

        public Capacity Capacity { get; set; }

        public ICollection<HostCapacity> HostCapacities { get; set; }

        public GameCapacity()
        {
            _gameCapacityId = Guid.NewGuid();

            Game = new();

            Capacity = new();

            HostCapacities = new Collection<HostCapacity>();
        }
    }
}
