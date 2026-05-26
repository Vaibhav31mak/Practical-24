namespace Practical24.DAL.UnitOfWork;

public interface IUnitOfWork
{
    IRepository<Employee> Employees { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
