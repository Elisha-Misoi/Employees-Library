using System;
using System.Collections.Generic;
using System.Linq;
using EmployeesLibrary.Models;

namespace EmployeesLibrary.Utils
{
    public static class Helpers
    {
        // Helper function (closure) that gets the ids of the employees under a manager (directly and indirectly)
        public static List<string> GetChildrenIds(List<Employee> employeesList, Employee currentEmployee)
        {
            List<string> childIDs = new List<string>();
            void GetChildEmployee(List<Employee> employees, Employee employee)
            {
                var parents = employeesList.Where(s => s.Manager_ID.Equals(employee.Employee_ID));
                foreach (var parent in parents)
                {
                    childIDs.Add(parent.Employee_ID);
                    GetChildEmployee(employees, parent);
                }
            }

            GetChildEmployee(employeesList, currentEmployee);
            return childIDs;
        }
    }
}
