namespace BLL.Models
{
    public class UserToken
    {
        private string
            _token = string.Empty,
            _message = string.Empty;

        public string Token { get => _token; set => _token = value; }

        public DateTime Expiration { get; set; }

        public string Message { get => _message; set => _message = value; }
    }
}
