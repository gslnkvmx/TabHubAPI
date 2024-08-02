namespace TabHubAPI.Contracts
{
    public record CreateTabRequest(string Url, Guid collection, string? Description);
}
