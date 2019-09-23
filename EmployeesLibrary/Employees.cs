using System;
using System.Collections.Generic;
using System.Linq;
using EmployeesLibrary.Models;
using EmployeesLibrary.Utils;
using System.Threading.Tasks;

namespace EmployeesLibrary
{
    public class Employees
    {
        // List of employees
        readonly List<Employee> employeeList;

        public Employees(string[] employees)
        {
            try
            {
                // check if source is null or empty
                if (employees != null && employees.Any())
                {
                    employeeList = new List<Employee>();

                    // loop through the employees source
                    foreach (var item in employees)
                    {
                        // split the csv string to get the individual details of an employee
                        string[] details = item.Split(',');

                        // check if the employee has an id
                        if (string.IsNullOrEmpty(details[0]))
                        {
                            Console.WriteLine("Employee ID is missing, skipping employee...");
                            continue;
                        }

                        // check if a CEO already exists
                        bool ceo_exists = employeeList.Any(s => s.Is_CEO);

                        if (string.IsNullOrEmpty(details[1]) && ceo_exists)
                        {
                            Console.WriteLine($"CEO already exists, skipping employee with the id: {details[0]}");
                            continue;
                        }

                        // ensure that a manager is also an employee
                        if (!string.IsNullOrEmpty(details[1]))
                        {
                            var manager_appearance = employees.Count(s => s.Contains(details[1]));

                            if (manager_appearance < 2)
                            {
                                Console.WriteLine($"Manager must also be an employee, skipping employee with the id: {details[0]}");
                                continue;
                            }
                        }

                        // check if salary is a valid integer
                        bool valid_salary = int.TryParse(details[2], out int salary);

                        if (!valid_salary)
                        {
                            Console.WriteLine($"Salary is not a valid integer, skipping employee with the id: {details[0]}");
                            continue;
                        }

                        // check if the employee already exists
                        var existing_employee = employeeList.FirstOrDefault(s => s.Employee_ID.Equals(details[0]));

                        if (existing_employee != null)
                        {
                            // ensure the employee has only one manager
                            if (!string.IsNullOrEmpty(existing_employee.Manager_ID) && !existing_employee.Manager_ID.Equals(details[1]))
                            {
                                Console.WriteLine($"Employee cannot have more than one manager, skipping employee with the id: {details[0]}");
                                continue;
                            }

                            /// <summary>
                            /// Replace employee details if does not have more than one manager. 
                            /// This essentially updates the salary of the employee and adds
                            /// Manager_ID if present and did not exist in the case of CEO where
                            /// the employee seizes being a CEO
                            /// </summary>
                            var existing_employee_index = employeeList.IndexOf(existing_employee);

                            employeeList[existing_employee_index] = new Employee
                            {
                                Employee_ID = details[0],
                                Manager_ID = details[1],
                                Salary = salary
                            };
                        }
                        else
                        {
                            // add employee if does not exist
                            employeeList.Add(new Employee
                            {
                                Employee_ID = details[0],
                                Manager_ID = details[1],
                                Salary = salary
                            });
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("The source was null or empty.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public long ManagerSalaryBudget(string manager_id)
        {
            long budget = 0;

            try
            {
                // check if list of employees is null or empty
                if (employeeList != null && employeeList.Any())
                {
                    // get the manager
                    var manager = employeeList.FirstOrDefault(s => s.Employee_ID.Equals(manager_id));

                    // check if manager exists
                    if (manager != null)
                    {
                        // add the manager salary to the budget
                        budget = manager.Salary;

                        // get ids of employees under the manager
                        var children_ids = Helpers.GetChildrenIds(employeeList, manager);

                        // check if there are employees under the manager
                        if (children_ids.Any())
                        {
                            // add the salaries of the employees to the overall budget
                            foreach (var employee_id in children_ids)
                            {
                                var child_employee = employeeList.FirstOrDefault(s => s.Employee_ID.Equals(employee_id));
                                if (child_employee != null)
                                {
                                    budget += child_employee.Salary;
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("The specified manager does not exist.");
                    }
                }
                else
                {
                    throw new ArgumentException("No employee exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return budget;
        }
    }
}
