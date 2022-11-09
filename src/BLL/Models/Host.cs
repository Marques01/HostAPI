using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class Host
    {
        private Guid
            _hostId = default;

        private string
            _name = string.Empty,
            _createAt = string.Empty,
            _updateAt = string.Empty;

        private int
            _door = default;

        private bool
            _enabled = false;

        public Guid HostId { get => _hostId; set => _hostId = value; }

        public string Name { get => _name; set => _name = value; }

        public string CreateAt { get => _createAt; set => _createAt = value; }

        public string UpdateAt { get => _updateAt; set => _updateAt = value; }

        public int Door { get => _door; set => _door = value; }

        public bool Enabled { get => _enabled; set => _enabled = value; }

        public ICollection<HostCapacity> HostCapacities { get; set; }

        public Host()
        {
            _hostId = Guid.NewGuid();

            _createAt = DateTime.Now.ToString("yyyy/MM/dd");

            HostCapacities = new Collection<HostCapacity>();
        }
    }
}
