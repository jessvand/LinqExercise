using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            var numbers = new List<int>() { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 25, 26, 28, 30 };

            Console.WriteLine();

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum: {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average:{numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console

            var nums = numbers;

            Console.WriteLine($"Numbers in ascending order:");
            numbers.OrderBy(number => number).ToList().ForEach(number => Console.WriteLine(number));

            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine($"Numbers in descending order:");
            numbers.OrderByDescending(number => number).ToList().ForEach(number => Console.WriteLine(number));

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine($"Numbers greater than six:");
            numbers.Where(numbers => numbers > 6).ToList().ForEach(numbers => Console.WriteLine(numbers));

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine($"Only four numbers:");

            var someNumbers = numbers.OrderBy(number => number).ToList();

            foreach (var number in someNumbers.Take(4))
            {
                Console.WriteLine(number);
            }





            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            Console.WriteLine($"My Age:");

            numbers.Select((number, index) => index == 4 ? 36 : number).OrderByDescending(number => numbers).ToList().ForEach(numbers => Console.WriteLine(numbers));




            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            Console.WriteLine("Starts with C and/or S");

            var sortEmployees = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            foreach (var person in sortEmployees)
            {
                Console.WriteLine($"Employee Name: {person.FirstName}, Age: {person.Age}");
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employee's that are 26 or older");
            var overTwentySix = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.Age).ThenBy(person => person.FirstName).ToList();

          
            foreach(var person in overTwentySix)
            {
                Console.WriteLine($"{person.FullName}\n Age: {person.Age}");
            }


            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var tenuredEmployees = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35).ToList();

            Console.WriteLine($"Sum of tenured employees years of experience:{tenuredEmployees.Sum(person => person.YearsOfExperience)}");


            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var juniorEmployees = employees.Where(person => person.YearsOfExperience <= 10 && person.Age < 35).ToList();

            Console.WriteLine($"Average YOE: {juniorEmployees.Average(person => person.YearsOfExperience)}");


            //TODO: Add an employee to the end of the list without using employees.Add()
            employees= employees.Append(new Employee ("Joseph", "Gilgun", 40, 7)).ToList();
            employees.ForEach(person => Console.WriteLine(person.FullName));

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
