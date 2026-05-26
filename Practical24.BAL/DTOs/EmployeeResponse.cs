namespace Practical24.BAL.DTOs;

public sealed record EmployeeResponse
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public decimal Salary { get; init; }
    public int DepartmentId { get; init; }
    public required string EmailId { get; init; }
    public DateTime JoiningDate { get; init; }
    public bool Status { get; init; }
}
