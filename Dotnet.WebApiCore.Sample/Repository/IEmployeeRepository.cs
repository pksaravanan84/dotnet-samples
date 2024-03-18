using DotNet.Models;

namespace Dotnet.WebApiCore.Sample.Repository;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetEmployees();
    Task<Employee> GetEmployee(int employeeId);
    Task<Employee> AddEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
}