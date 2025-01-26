using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMCourseStore.Modules.Orders.Domain;

namespace MMCourseStore.Modules.Orders.Data;
internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(c => c.Id).ValueGeneratedNever();
    }
}
