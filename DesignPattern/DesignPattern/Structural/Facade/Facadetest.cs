using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Structural.Facade
{
    public class Facadetest
    {
        private readonly IHRFacade hRFacade = new HRFacade();
        [Fact]
        public void ShouldWork()
        {
            IEnumerable<Department> departments = hRFacade.GetAllDepartments();
            IEnumerable<Employee> employees = hRFacade.GetAllEmployees();
            Manager manager = hRFacade.GetMangerById("M01");

            departments.Should().HaveCount(2);
            employees.Should().HaveCount(3);
            manager.Should().NotBeNull();
        }
    }
}
