using DotNet.Models;

namespace Dotnet.WebApiCore.Sample.Repository;

public interface IDepartmentRepository
{
    IEnumerable<Department> GetDepartments();
    Department GetDepartment(int departmentId);
}
