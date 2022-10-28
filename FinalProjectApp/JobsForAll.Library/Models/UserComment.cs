namespace JobsForAll.Library.Models
{
    public class UserComment
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Comment Comment { get; set; }
    }
}
