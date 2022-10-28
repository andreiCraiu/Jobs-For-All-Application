namespace JobsForAll.SqlDatabase.Models
{
    internal class DbJob
    {
        public int ID { get; set; }
        public string JobTitle { get; set; }
        public string JobCategory { get; set; }
        public double Price { get; set; }
        public bool IsPriceNegociable { get; set; }
        public string Description { get; set; }
    }
}
