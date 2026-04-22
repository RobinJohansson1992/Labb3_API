namespace Labb3_API.models.DTOs
{
    public class UserDTOs
    {
        public record CreateAddUserRequest()
        {
            public string? Name { get; set; }
            public string? PhoneNumber { get; set; }
        }
    }
}
