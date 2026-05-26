
namespace Practical24.DAL.Context;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees => Set<Employee>();

    // Fluent API configurations especially for Salary property to
    // ensure it has the correct precision and scale in the database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.EmailId).HasMaxLength(150).IsRequired();
            entity.Property(e => e.Salary).HasPrecision(18, 2);
        });
    }
}
