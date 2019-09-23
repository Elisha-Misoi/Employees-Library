[![Codacy Badge](https://api.codacy.com/project/badge/Grade/4ccc8253c76049c89cbba2585c3994cb)](https://www.codacy.com/manual/Elisha-Misoi/Employees-Library?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=Elisha-Misoi/Employees-Library&amp;utm_campaign=Badge_Grade)

# Employees-Library

> .NET Library that handles employee hierarchy. 

## The challenge

Develop a .NET library assembly (DLL) for a system that handles the employee hierarchy, implemented as class Employees. This class has a constructor that takes a CSV string that contains all the employees from the company, the manager they report to, and the employee’s salary. Develop the library assembly that contains the code for the questions below. Make sure to provide unit tests for your code and an efficient solution.

a. Create a constructor that takes a CSV1 input string containing a list of employee info and validates the string. The first CSV column contains the id of the employee, the second one contains the id of the manager, and the third one contains the employee’s salary. The CEO of the company is the only employee that doesn't have a manager; in his case, the manager field will be empty. The list is not guaranteed to be sorted and can come in any random order.

The constructor should validate that:

    1. The salaries in the CSV are valid integer numbers.
    2. One employee does not report to more than one manager.
    3. There is only one CEO, i.e. only one employee with no manager.
    4. There is no circular reference, i.e. a first employee reporting to a second employee that is also under
    the first employee.
    5. There is no manager that is not an employee, i.e. all managers are also listed in the employee column.

b. Add an instance method that returns the salary budget from the specified manager. The salary budget from a manager is defined as the sum of the salaries of all the employees reporting (directly or indirectly) to a specified manager, plus the salary of the manager.

    Input type: String  
    Return type: long  
