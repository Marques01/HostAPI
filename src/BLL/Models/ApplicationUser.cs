using Microsoft.AspNetCore.Identity;

namespace BLL.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {   
        private string 
            _firstName = string.Empty,
            _lastName = string.Empty,
            _lastLogin = string.Empty,
            _createAt = string.Empty;

        private Guid
            _profileId = default;

        public string Name { get => _firstName; set => _firstName = value; }
        
        public string LastName { get => _lastName; set => _lastName = value; }

        public string LastLogin { get => _lastLogin; set => _lastLogin = value; }

        public string CreateAt { get => _createAt; set => _createAt = value; }

        public Guid ProfileId { get => _profileId; set => _profileId = value; }

        public ApplicationUser()
        {
            _createAt = DateTime.Now.ToString("dd/MM/aaaa HH:mm:ss");
        }
    }
}
