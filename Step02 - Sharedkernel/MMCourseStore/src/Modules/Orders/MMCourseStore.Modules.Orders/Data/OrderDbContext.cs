using Microsoft.EntityFrameworkCore;
using MMCourseStore.Modules.Orders.Domain;

namespace MMCourseStore.Modules.Orders.Data;
public class OrderDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.HasDefaultSchema("orders");
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }
}
