namespace Labb3_API.models
{
    public class Link
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public int UserId { get; set; }
        public int InterestId { get; set; }


        //Navigation properties:
        public User? User { get; set; }
        public Interest? Interest { get; set; }
    }
}
