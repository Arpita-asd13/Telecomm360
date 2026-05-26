using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telecom360.Domain.Entities;
using Telecom360.Infrastructure.Repository.Interface;

namespace Telecom360.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private static List<Telecom360.Domain.Entities.Order> _orders = new();

    public Task<Telecom360.Domain.Entities.Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = _orders.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(order);
    }

    public Task<List<Telecom360.Domain.Entities.Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_orders);
    }

    public Task AddAsync(Telecom360.Domain.Entities.Order order, CancellationToken cancellationToken = default)
    {
        _orders.Add(order);
        return Task.CompletedTask;
    }

    public void Update(Telecom360.Domain.Entities.Order order)
    {
        var existing = _orders.FirstOrDefault(x => x.Id == order.Id);
        if (existing != null)
        {
            _orders.Remove(existing);
            _orders.Add(order);
        }
    }

    public void Remove(Telecom360.Domain.Entities.Order order)
    {
        _orders.Remove(order);
    }

    public Task<bool> ExistsAsync(Guid subscriberId, Guid productId, CancellationToken cancellationToken = default)
    {
        var exists = _orders.Any(o =>
            o.SubscriberId == subscriberId &&
            o.ProductId == productId &&
            o.Status != "COMPLETED" &&
            o.Status != "CANCELLED");

        return Task.FromResult(exists);
    }

    public Task<bool> HasIncompleteTasksAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        var order = _orders.FirstOrDefault(x => x.Id == orderId);

        if (order == null) return Task.FromResult(false);

        var has = order.ProvisioningTasks.Any(t =>
            t.Status == "PENDING" ||
            t.Status == "IN_PROGRESS" ||
            t.Status == "FAILED");

        return Task.FromResult(has);
    }

    public Task<Telecom360.Domain.Entities.Order?> GetWithTasksAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = _orders.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(order);
    }
}
