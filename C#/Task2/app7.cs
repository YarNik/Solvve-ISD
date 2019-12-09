using System;

namespace ConsoleApp7
{
    class Program
    {
        class Employee 
        {
            string name, lastName;
            string position = "worker";
            int workExperience;
            double taxRate = 0.15;
            double salary, tax;

            public Employee(string name, string lastName) 
            {
                this.name = name;
                this.lastName = lastName;
            }
            
            public string Position { set { position = value; } }
            public int WorkExperience { set { workExperience = value; } }
            public void SalaryCalculator() 
            {
                if (position == "worker") { salary = Math.Round((8000 + 8000 * workExperience * 0.05), 2); }
                if (position == "manager") { salary = Math.Round((15000 + 15000 * workExperience * 0.05), 2); }
                if (position == "supervisor") { salary = Math.Round((20000 + 20000 * workExperience * 0.05), 2); }
                tax = Math.Round((salary * taxRate),2);
            }

            public void EmployeeShow() 
            {
                Console.WriteLine($"{name} {lastName} {position}, оклад {salary}, налоговый сбор {tax}.");
                Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {
            Employee ivan = new Employee("Ivan", "Ivanov");
            ivan.SalaryCalculator();
            ivan.EmployeeShow();
            ivan.Position = "manager";
            ivan.WorkExperience = 3;
            ivan.SalaryCalculator();
            ivan.EmployeeShow();
        }
    }
}
