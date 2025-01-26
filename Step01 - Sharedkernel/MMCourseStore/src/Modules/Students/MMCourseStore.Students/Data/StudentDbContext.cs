using Microsoft.EntityFrameworkCore;
using MMCourseStore.Modules.Students.Domain;

namespace MMCourseStore.Modules.Students.Data;
internal class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
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
        modelBuilder.HasDefaultSchema("student");
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }
}
