namespace Labb3_API.models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }


        //Navigation properties
        public ICollection<Interest>? Interests { get; set; } = [];
        public ICollection<Link>? Links { get; set; } = [];
    }
}
