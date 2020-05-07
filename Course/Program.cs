using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using Course.Entities;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double searchedSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] values = sr.ReadLine().Split(',');
                    string name = values[0];
                    string email = values[1];
                    double salary = double.Parse(values[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }
            }

            var r1 = list.Where(e => e.Salary > 2000.0).OrderBy(e => e.Email).Select(e => e.Email);
            Console.WriteLine("Email of people whose salary is more than 2000.00:");
            foreach(string s in r1)
            {
                Console.WriteLine(s);
            }

            var r2 = list.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + r2.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
