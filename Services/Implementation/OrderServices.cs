using Telecom360.Infrastructure.Repository.Interface;
using Telecom360.Domain.Entities;

public class OrderServices : IOrderServices
{
    private readonly IOrderRepository _orderRepository;
    public OrderServices(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<Order?> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _orderRepository.GetByIdAsync(id, cancellationToken);
    }
    public async Task<List<Order>> GetAllOrdersAsync(CancellationToken cancellationToken = default)
    {
        return await _orderRepository.GetAllAsync(cancellationToken);
    }
    public async Task CreateOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _orderRepository.AddAsync(order, cancellationToken);
    }
    public async Task UpdateOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        _orderRepository.Update(order);
        await Task.CompletedTask;
    }
    public async Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await _orderRepository.GetByIdAsync(id, cancellationToken);
        if (order != null)
        {
            _orderRepository.Remove(order);
        }
    }
}
