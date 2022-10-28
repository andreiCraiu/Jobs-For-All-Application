namespace JobsForAll.Domain.Models
{
    public class JobRequester
    {
        public int ID { get; set; }
        public Job Job { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
