namespace BLL.Models
{
    public class HostLoggin
    {
        private Guid
            _hostLogginId = default;

        private Guid
            _hostId = default;

        private string
            _name = string.Empty,
            _createAt = string.Empty,
            _updateAt = string.Empty,
            _removeAt = string.Empty;

        private int
            _door = default;

        private bool
            _enabled = false;

        public Guid HostLogginId { get => _hostLogginId; set => _hostLogginId = value; }

        public Guid HostId { get => _hostId; set => _hostId = value; }

        public string Name { get => _name; set => _name = value; }

        public int Door { get => _door; set => _door = value; }

        public bool Enabled { get => _enabled; set => _enabled = value; }

        public string CreateAt { get => _createAt; set => _createAt = value; }

        public string UpdateAt { get => _updateAt; set=> _updateAt = value; }

        public string RemoveAt { get => _removeAt; set => _removeAt = value; }

        public HostLoggin()
        {
            _hostLogginId = Guid.NewGuid();

            CreateAt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
