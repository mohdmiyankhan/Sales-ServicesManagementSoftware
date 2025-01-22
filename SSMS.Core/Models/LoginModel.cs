namespace SSMS.Core.Models
{
    public class LoginModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    
    public class Login
    {
        public string Message { get; set; } = null!;
        public int Status { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public int ExpiryInHours { get; set; }
    }
}
