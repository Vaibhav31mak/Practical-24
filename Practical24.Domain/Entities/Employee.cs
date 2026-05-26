namespace Practical24.Domain.Entities;

public sealed class Employee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    public required string EmailId { get; set; }
    public DateTime JoiningDate { get; set; }
    public bool Status { get; set; }
}
