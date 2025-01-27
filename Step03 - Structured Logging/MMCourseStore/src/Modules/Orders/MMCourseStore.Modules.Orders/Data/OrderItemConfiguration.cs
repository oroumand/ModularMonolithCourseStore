using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMCourseStore.Modules.Orders.Domain;

namespace MMCourseStore.Modules.Orders.Data;

internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(c => c.Id).ValueGeneratedNever();
    }
}