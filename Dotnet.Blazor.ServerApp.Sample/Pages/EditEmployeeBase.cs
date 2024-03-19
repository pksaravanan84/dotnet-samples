using Dotnet.Blazor.ServerApp.Sample.Services;
using DotNet.Models;
using Microsoft.AspNetCore.Components;

namespace Dotnet.Blazor.ServerApp.Sample.Pages
{
    public class EditEmployeeBase: ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Employee.ConfirmEmail = Employee.Email;
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentId.ToString();
        }
    }
}
