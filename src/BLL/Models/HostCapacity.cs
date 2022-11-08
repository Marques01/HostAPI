using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class HostCapacity
    {
        private Guid
            _hostCapacityId = default,
            _hostId = default,
            _gameCapacityId = default;

        public Guid HostCapacityId { get => _hostCapacityId; set => _hostCapacityId = value; }

        public Guid HostId { get => _hostId; set => _hostId = value; }

        public Guid GameCapacityId { get => _gameCapacityId; set=> _gameCapacityId = value; }

        public Host Host { get; set; }

        public GameCapacity GameCapacity { get; set; }

        public HostCapacity()
        {
            _hostCapacityId = Guid.NewGuid();

            Host = new();

            GameCapacity = new();
        }
    }
}
