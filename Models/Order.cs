namespace Telecom360.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string FulfillmentSteps { get; set; } = string.Empty;
    }
}