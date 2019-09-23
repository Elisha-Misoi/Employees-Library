using Xunit;
using System.IO;
using EmployeesLibrary;

namespace UnitTest
{
    public class UnitTest
    {
        
        [Fact]
        public void Test_ShouldAddEmployeesAndReturnManagerBudget()
        {
            var source = File.ReadAllLines("../../../employees.txt");

            Employees employees = new Employees(source);

            long expected = 3300;

            long actual = employees.ManagerSalaryBudget("Employee1");

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Test_EmployeeShouldNotHaveMoreThanOneManager()
        {
            var source = File.ReadAllLines("../../../test_control.txt");

            Employees employees = new Employees(source);

            long expected = 800;

            long actual = employees.ManagerSalaryBudget("Employee3");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_ShouldNotHaveMoreThanOneCEO()
        {
            var source = File.ReadAllLines("../../../test_control3.txt");

            Employees employees = new Employees(source);

            long expected = 800;

            long actual = employees.ManagerSalaryBudget("Employee3");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_EmployeeIDShouldNotBeMissing()
        {
            var source = File.ReadAllLines("../../../test_control4.txt");

            Employees employees = new Employees(source);

            long expected = 3300;

            long actual = employees.ManagerSalaryBudget("Employee1");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_ManagerShouldAlsoBeEmployee()
        {
            var source = File.ReadAllLines("../../../test_control2.txt");

            Employees employees = new Employees(source);

            long expected = 3300;

            long actual = employees.ManagerSalaryBudget("Employee1");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_ShouldNotAcceptInvalidSalary()
        {
            var source = File.ReadAllLines("../../../test_control1.txt");

            Employees employees = new Employees(source);

            long expected = 2800;

            long actual = employees.ManagerSalaryBudget("Employee1");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_EmployeesSourceShouldNotBeNull()
        {
            string[] source = null;

            Employees employees = new Employees(source);

            long expected = 0;

            long actual = employees.ManagerSalaryBudget("Random");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_ShouldValidateManagerExists()
        {
            var source = File.ReadAllLines("../../../employees.txt");

            Employees employees = new Employees(source);

            long expected = 0;

            long actual = employees.ManagerSalaryBudget("RandomManager");

            Assert.Equal(expected, actual);
        }
    }
}
