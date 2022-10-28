namespace JobsForAll.SqlDatabase.Models
{
    internal class DbUserComment
    {
        public int Id { get; set; }
        public DbApplicationUser ApplicationUser { get; set; }
        public DbComment Comment { get; set; }
    }
}
