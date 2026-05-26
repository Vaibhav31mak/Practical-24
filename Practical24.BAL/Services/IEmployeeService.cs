
namespace Practical24.BAL.Services;

public interface IEmployeeService
{
    Task<EmployeeResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<EmployeeResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<EmployeeResponse> CreateAsync(CreateEmployeeRequest request, CancellationToken cancellationToken = default);
    Task<EmployeeResponse?> UpdateAsync(UpdateEmployeeRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
