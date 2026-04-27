namespace Labb3_API.models.DTOs
{
    public class LinkDTOs
    {
        public record CreateAddLinkRequest()
        {
            public string? Url { get; init; }
        }

        public record LinkResponse
        {
            public int Id { get; init; }
            public string? Url { get; init; }
            public int UserId { get; init; }
            public int InterestId { get; init; }
        }
    }
}
