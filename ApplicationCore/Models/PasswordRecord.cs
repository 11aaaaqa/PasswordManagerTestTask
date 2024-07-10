namespace ApplicationCore.Models
{
    public class PasswordRecord
    {
        public Guid Id { get; set; }

        public string SiteOrMailName { get; set; }

        public string Password { get; set; }

        public DateOnly CreatedAt { get; set; }
    }
}
