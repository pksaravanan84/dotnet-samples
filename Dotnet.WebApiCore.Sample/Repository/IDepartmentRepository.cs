using DotNet.Models;

namespace Dotnet.WebApiCore.Sample.Repository;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetDepartments();
    Task<Department> GetDepartment(int departmentId);
}
