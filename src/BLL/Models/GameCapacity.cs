namespace BLL.Models
{
    public class GameCapacity
    {
        private Guid
            _gameCapacityId = default,
            _gameId = default,
            _capacityId = default,
            _hostId = default;

        public Guid GameCapacityId { get => _gameCapacityId; set => _gameCapacityId = value; }

        public Guid GameId { get => _gameId; set => _gameId = value; }

        public Guid CapacityId { get => _capacityId; set => _capacityId = value; }

        public Guid HostId { get => _hostId; set => _hostId = value; }

        public Game Game { get; set; }

        public Capacity Capacity { get; set; }

        public Host Host { get; set; }

        public GameCapacity()
        {
            _gameCapacityId = Guid.NewGuid();

            Game = new();

            Capacity = new();

            Host = new();
        }
    }
}
