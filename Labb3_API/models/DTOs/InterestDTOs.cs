namespace Labb3_API.models.DTOs
{
    public class InterestDTOs
    {
        public record CreateAddInterestRequest()
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
        }
    }
}
