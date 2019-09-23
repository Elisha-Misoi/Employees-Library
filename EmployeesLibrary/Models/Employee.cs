using System;

namespace EmployeesLibrary.Models
{
    public class Employee
    {
        public string Employee_ID { get; set; }

        public string Manager_ID { get; set; }

        public int Salary { get; set; }

        public bool Is_CEO
        {
            get
            {
                if (string.IsNullOrEmpty(Manager_ID))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
