

using Telecom360.Domain.Entities;

public interface IOrderServices
{
    Task<Order?> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Order>> GetAllOrdersAsync(CancellationToken cancellationToken = default);
    Task CreateOrderAsync(Order order, CancellationToken cancellationToken = default);
    Task UpdateOrderAsync(Order order, CancellationToken cancellationToken = default);
    Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken = default);
}
