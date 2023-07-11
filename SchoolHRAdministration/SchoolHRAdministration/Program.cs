﻿using HRAdministrationAPI;
using System;
using System.Linq;
namespace SchoolHRAdministration
{
    class Program
    {
        static void Main(string[] args) {
            decimal totalSalaries = 0;
            List<IEmployee> employees= new List<IEmployee>();

            SeedData(employees);

            //foreach(IEmployee employee in employees)
            //{
            //    totalSalaries += employee.Salary;
            //}
            //Console.WriteLine($"Total Annual Salaries (including bonus) : {totalSalaries}");

            // Instead of this above 3 line of code we can use Linq to write the code in single line.
            // Read this below concepts :
            // LINQ , ExtensionMethod, Delegate, Lambda Expression

            Console.WriteLine($"Total Annual Salaries (including bonus) : {employees.Sum(e => e.Salary)}");

            Console.ReadKey();
        }

        public static void SeedData(List<IEmployee> employees) {
            IEmployee teacher1 = new Teacher
            {
                ID = 1,
                FirstName = "Aster",
                LastName = "Kokanur",
                Salary = 40000
            };
            employees.Add(teacher1);

            IEmployee teacher2 = new Teacher
            {
                ID = 2,
                FirstName = "Rogue",
                LastName = "Shetty",
                Salary = 40000
            };
            employees.Add(teacher2);

            IEmployee headOfDepartment = new HeadOfDepartment
            {
                ID = 3,
                FirstName = "Brenda",
                LastName = "Mullins",
                Salary = 50000
            };
            employees.Add(headOfDepartment);

            IEmployee deputyHeadMaster = new DeputyHeadMaster
            {
                ID = 4,
                FirstName = "Devlin",
                LastName = "Brown",
                Salary = 60000
            };
            employees.Add(deputyHeadMaster);

            IEmployee headMaster = new HeadMaster
            {
                ID = 5,
                FirstName = "Damien",
                LastName = "Jonas",
                Salary = 80000
            };
            employees.Add(headMaster);

        }
    }

    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
    }

    public class HeadOfDepartment : EmployeeBase {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
    }

    public class DeputyHeadMaster : EmployeeBase {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
    }

    public class HeadMaster : EmployeeBase {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
    }
}