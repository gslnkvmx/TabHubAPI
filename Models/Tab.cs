namespace TabHubAPI.Models
{
    public class Tab
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string? Description {  get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid TabCollectionId { get; set; }

        public Tab(string url, Guid tabCollectionId, string? description = null)
        {
            Url = url;
            TabCollectionId = tabCollectionId;
            Description = description;
            CreatedAt = DateTime.UtcNow.Date;
        }   
    }
}
