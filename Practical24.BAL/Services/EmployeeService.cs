

namespace Practical24.BAL.Services;

public sealed class EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<EmployeeResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(id, cancellationToken);
        if (employee is null)
        {
            return null;
        }

        return _mapper.Map<EmployeeResponse>(employee);
    }

    public async Task<IReadOnlyList<EmployeeResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var employees = await _unitOfWork.Employees.GetAllAsync(cancellationToken);
        var responses = new List<EmployeeResponse>();
        foreach (var employee in employees)
        {
            responses.Add(_mapper.Map<EmployeeResponse>(employee));
        }

        return responses;
    }

    public async Task<EmployeeResponse> CreateAsync(CreateEmployeeRequest request, CancellationToken cancellationToken = default)
    {
        var employee = _mapper.Map<Employee>(request);
        await _unitOfWork.Employees.AddAsync(employee, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<EmployeeResponse>(employee);
    }

    public async Task<EmployeeResponse?> UpdateAsync(UpdateEmployeeRequest request, CancellationToken cancellationToken = default)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id, cancellationToken);
        if (employee is null)
        {
            return null;
        }
        _mapper.Map(request, employee);
        _unitOfWork.Employees.Update(employee);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<EmployeeResponse>(employee);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(id, cancellationToken);
        if (employee is null)
        {
            return false;
        }
        _unitOfWork.Employees.Remove(employee);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
