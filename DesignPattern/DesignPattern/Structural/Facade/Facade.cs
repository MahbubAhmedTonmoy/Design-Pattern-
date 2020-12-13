using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DesignPattern.Structural.Facade
{
    /// <summary>
    /// Façade প্যাটার্ন আমাদের একটি সিম্পল ইন্টারফেস এর মাধ্যমে পুরো একটি সাবসিস্টেম কে রিপ্রেজেন্ট করতে সাহায্য করে 
    /// Implement a single interface that delegate request to subsystems.
    /// Simpler interface for complex module/subsystem.
    /// </summary>
    public interface IHRFacade
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Department> GetAllDepartments();
        Manager GetMangerById(string id);
    }

    public class HRFacade : IHRFacade
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;
        private readonly IManagerService managerService;
        public HRFacade()
        {
            this.employeeService =new EmployeeService();
            this.departmentService =new DepartmentService();
            this.managerService =new ManagerService();
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return departmentService.GetAllDepartments();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeService.GetAllEmployees();
        }

        public Manager GetMangerById(string id)
        {
            return managerService.GetManagerById(id);
        }
    }
    public interface IManagerService
    {
        public Manager GetManagerById(string id);
    }

    public class ManagerService : IManagerService
    {
        public Manager GetManagerById(string id)
        {
            return new Manager
            {
                Id = id,
                Name = $"Manager-{id}",
                Age = 45
            };
        }
    }
    public interface IDepartmentService
    {
        public IEnumerable<Department> GetAllDepartments();
    }

    public class DepartmentService : IDepartmentService
    {
        public IEnumerable<Department> GetAllDepartments()
        {
            var managerIT = new Manager
            {
                Id = "M01",
                Name = $"Manager-M01",
                Age = 45
            };
            var managerFi = new Manager
            {
                Id = "M02",
                Name = $"Manager-M02",
                Age = 50
            };

            return new[]
            {
                new Department{Id = "D01", Name = "IT", Manager = managerIT},
                new Department{Id = "D02", Name = "Finance", Manager = managerFi},
            };
        }
    }
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetAllEmployees();
    }
    public class EmployeeService : IEmployeeService
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            return new[]
            {
                new Employee{Id = "E01", Name = "Employee-E01"},
                new Employee{Id = "E02", Name = "Employee-E02"},
                new Employee{Id = "E03", Name = "Employee-E03"},
            };
        }
    }

    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Manager Manager { get; set; }
    }

    public class Manager : Employee
    {
        public int Age { get; set; }
    }
}
