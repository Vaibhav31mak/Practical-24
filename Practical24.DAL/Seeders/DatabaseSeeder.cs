namespace Practical24.DAL.Seeders;

public sealed class DatabaseSeeder(ApplicationDbContext context) : IDatabaseSeeder
{
    private readonly ApplicationDbContext _context = context;

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (await _context.Employees.AnyAsync(cancellationToken))
        {
            return;
        }

        var employees = new List<Employee>
        {
            new()
            {
                Name = "Vaibhav Makwana",
                Salary = 85000m,
                DepartmentId = 1,
                EmailId = "vaibhav.makwana@practical23.com",
                JoiningDate = DateTime.UtcNow.AddYears(-3),
                Status = true
            },
            new()
            {
                Name = "Madhav Makwana",
                Salary = 62000m,
                DepartmentId = 3,
                EmailId = "madhav.makwana@practical23.com",
                JoiningDate = DateTime.UtcNow.AddYears(-2),
                Status = true
            },
            new()
            {
                Name = "Rohan Mehta",
                Salary = 70000m,
                DepartmentId = 4,
                EmailId = "rohan.mehta@practical23.com",
                JoiningDate = DateTime.UtcNow.AddYears(-1),
                Status = true
            },
            new()
            {
                Name = "Milan Vala",
                Salary = 90000m,
                DepartmentId = 5,
                EmailId = "milan.vala@practical23.com",
                JoiningDate = DateTime.UtcNow.AddYears(-4),
                Status = true
            }
        };

        await _context.Employees.AddRangeAsync(employees, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
