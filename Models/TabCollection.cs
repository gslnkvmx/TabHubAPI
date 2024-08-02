namespace TabHubAPI.Models
{
    public class TabCollection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Tab> Tabs { get; set; }

        public TabCollection(string name, string? description = null)
        {
            Name = name;
            Description = description;
            Tabs = new List<Tab>();
        }
    }
}
