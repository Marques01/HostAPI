using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class Host
    {
        private Guid
            _hostId = default;

        private string
            _name = string.Empty;

        private int
            _door = default;

        private bool
            _enabled = false;

        public Guid HostId { get => _hostId; set => _hostId = value; }

        public string Name { get => _name; set => _name = value; }

        public int Door { get => _door; set => _door = value; }

        public bool Enabled { get => _enabled; set => _enabled = value; }

        public ICollection<GameCapacity> GamesCapacities { get; set; }

        public Host()
        {
            _hostId = Guid.NewGuid();

            GamesCapacities = new Collection<GameCapacity>();
        }
    }
}
