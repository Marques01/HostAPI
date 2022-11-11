namespace BLL.Models
{
    public class HostCapacity
    {
        private int
            _hostCapacityId = default,
            _hostId = default,
            _gameCapacityId = default;

        public int HostCapacityId { get => _hostCapacityId; set => _hostCapacityId = value; }

        public int HostId { get => _hostId; set => _hostId = value; }

        public int GameCapacityId { get => _gameCapacityId; set=> _gameCapacityId = value; }

        public Host? Host { get; set; }

        public GameCapacity? GameCapacity { get; set; }        
    }
}
