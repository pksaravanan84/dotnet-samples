using DotNet.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Dotnet.Blazor.ServerApp.Sample.Services;


public class EmployeeService : IEmployeeService
{
    private readonly HttpClient httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
    }

    public async Task<Employee> GetEmployee(int id)
    {
        return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
    }
}