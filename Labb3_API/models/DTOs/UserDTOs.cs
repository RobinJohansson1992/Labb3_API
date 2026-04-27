namespace Labb3_API.models.DTOs
{
    public class UserDTOs
    {
        public record CreateAddUserRequest()
        {
            public string? Name { get; init; }
            public string? PhoneNumber { get; init; }
        }
    }
}
