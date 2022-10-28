namespace JobsForAll.SqlDatabase.Models
{
    internal class DbJobRequester
    {
        public int ID { get; set; }
        public DbJob Job { get; set; }
        public DbApplicationUser ApplicationUser { get; set; }
    }
}
