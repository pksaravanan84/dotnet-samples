using DotNet.Models;

namespace Dotnet.Blazor.ServerApp.Sample.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployees();
    Task<Employee> GetEmployee(int id);
}
