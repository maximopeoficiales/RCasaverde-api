namespace backend.Models
{
    public class UserAuthResponse
    {
        public string jwt { get; set; }
        public User user { get; set; }
    }
}
