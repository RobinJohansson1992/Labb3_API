namespace Labb3_API.models.DTOs
{
    public class LinkDTOs
    {
        public record CreateAddLinkRequest()
        {
            public string? Url { get; set; }
            public int UserId { get; set; }
            public int InterestId { get; set; }
        }
    }
}
