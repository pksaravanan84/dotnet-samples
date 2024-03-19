using DotNet.Models;

namespace Dotnet.Blazor.ServerApp.Sample.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
    }
}
