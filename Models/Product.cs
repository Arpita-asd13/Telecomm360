namespace Telecom360.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public int PriceModel { get; set; }
        public required string Status { get; set; }
    }
}