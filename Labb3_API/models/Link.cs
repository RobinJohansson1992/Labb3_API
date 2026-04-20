namespace Labb3_API.models
{
    public class Link
    {
        public int Id { get; set; }
        public string? Url { get; set; }

        //Navigation properties
        public int PersonId { get; set; }
        public Person? Person { get; set; }
        public int InterestId { get; set; }
        public Interest? Interest { get; set; }
    }
}
