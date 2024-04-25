namespace CRM.Models
{
    public class Accounts
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string>? Tags { get; set; } = new List<string>();

    }
}
