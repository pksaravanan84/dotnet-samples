﻿
using Dotnet.Blazor.ServerApp.Sample.Services;
using DotNet.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadEmployees();
        }

        private async Task LoadEmployees()
        {
            Employees = await EmployeeService.GetEmployees();
        }
    }
}