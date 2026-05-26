namespace Telecom360.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid SubscriberId { get; set; }
        public Guid ProductId { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<ProvisioningTask> ProvisioningTasks { get; set; } = new();
    }
}