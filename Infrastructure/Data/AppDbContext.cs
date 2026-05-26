using Microsoft.EntityFrameworkCore;
using Telecom360.Models;

namespace Telecom360.Infrastructure.Data
{ 
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Subscriber> Subscribers => Set<Subscriber>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Invoice> Invoices => Set<Invoice>();

        public DbSet<Payment> Payments => Set<Payment>();

        public DbSet<User> Users => Set<User>();

        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    }