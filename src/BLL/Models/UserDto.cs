namespace BLL.Models
{
    public class UserDto
    {
        private string
           _email = String.Empty,
           _password = String.Empty,
           _confirmPassword = String.Empty;
        
        public string Email { get => _email; set => _email = value; }
        
        public string Password { get => _password; set => _password = value; }
        
        public string ConfirmPassword { get => _confirmPassword; set => _confirmPassword = value; }
    }
}
