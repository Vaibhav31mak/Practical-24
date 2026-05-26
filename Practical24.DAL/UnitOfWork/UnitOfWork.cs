namespace Practical24.DAL.UnitOfWork;

public sealed class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;
    private IRepository<Employee>? _employees;

    public IRepository<Employee> Employees => _employees ??=
        new Repository<Employee>(_context);

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
