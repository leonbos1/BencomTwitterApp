namespace BencomTwitterApp.Models
{
    public class TwitterAccount
    {
        //username en displayname apart omdat 'ministerkene', bijvoorbeeld niet zoveel zegt, volledige naam is duidelijker in de dropdown
        public string? DisplayName { get; set; }
        public string? Username { get; set; }
    }
}
