namespace backend.Models
{
    public class StaffAuthResponse
    {
        public string jwt { get; set; }
        public Staff user { get; set; }
    }
}
