
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Telecom360.Infrastructure.Repository.Interface
{
    public interface IOrderRepository
    {
        using Telecom360.Domain.Entities;

        Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);

        Task AddAsync(Order order, CancellationToken cancellationToken = default);

        void Update(Order order);

        void Remove(Order order);

        Task<bool> ExistsAsync(
            Guid subscriberId,
            Guid productId,
            CancellationToken cancellationToken = default
        );

        Task<bool> HasIncompleteTasksAsync(
            Guid orderId,
            CancellationToken cancellationToken = default
        );

        Task<Telecom360.Domain.Entities.Order?> GetWithTasksAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );
    }

}
