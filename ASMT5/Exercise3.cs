using System;
using SalaryCalculator;
namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Basic Salary: ");
                double basicSalary = Convert.ToDouble(Console.ReadLine());
                double netSalary = Class1.CalculateNetSalary(basicSalary);
                Console.WriteLine($"Employee Name: {name}");
                Console.WriteLine($"Basic Salary: {basicSalary}");
                Console.WriteLine($"Net Salary: {netSalary}");

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the basic salary.");
            }

            catch(ApplicationException ex)
            {
                Console.WriteLine($"Application error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            
        }
    }
}