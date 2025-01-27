using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMCourseStore.Modules.Students.Domain;

namespace MMCourseStore.Modules.Students.Data;
internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.Property(c => c.FirstName).HasMaxLength(100);
        builder.Property(c => c.LastName).HasMaxLength(500);

        builder.HasData(
            new Student(1, "Hassan", "Rezaei"),
            new Student(2, "Mohammad", "Hassani"),
            new Student(3, "Aria", "Zohoori"),
            new Student(4, "Reza", "Abbasi")
            );
    }
}
