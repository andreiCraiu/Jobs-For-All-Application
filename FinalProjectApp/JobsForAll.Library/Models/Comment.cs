namespace JobsForAll.Library.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public string Author { get; set; }
    }
}
