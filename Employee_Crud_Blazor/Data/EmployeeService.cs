﻿using Employee_Crud_Blazor.Context;
using Microsoft.EntityFrameworkCore;

namespace Employee_Crud_Blazor.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        //Get All Employee List
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _applicationDbContext.Employees.ToListAsync();
        }

        //Add New Employee Record
        public async Task<bool> AddNewEmployee(Employee employee)
        {
            await _applicationDbContext.Employees.AddAsync(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Get Employee Record by Id
        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return employee;
        }

        //Update Employee Data
        public async Task<bool> UpdateEmployeeDetails(Employee employee)
        {
            _applicationDbContext.Employees.Update(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Delete Employee Data
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Remove(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
