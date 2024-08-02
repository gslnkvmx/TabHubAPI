namespace TabHubAPI.Models
{
    public class Tab
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string? Description {  get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid GroupId { get; set; }

        public Tab(string url, string? description = null)
        {
            Url = url;
            Description = description;
            CreatedAt = DateTime.UtcNow.Date;
        }   
    }
}
