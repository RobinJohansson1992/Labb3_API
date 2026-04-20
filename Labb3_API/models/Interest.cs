namespace Labb3_API.models
{
    public class Interest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }


        //Navigation properties:
        public ICollection<Person>? Persons { get; set; } = [];
        public ICollection<Link>? Links { get; set; } = [];
    }
}
