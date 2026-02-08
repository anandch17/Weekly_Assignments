using System;
using System.Collections.Generic;

namespace Requirement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of vehicles");
            int n = int.Parse(Console.ReadLine());

            List<Vehicle> vehicleList = new List<Vehicle>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                vehicleList.Add(Vehicle.CreateVehicle(input));
            }

            SortedDictionary<string, int> result =
                Vehicle.TypeWiseCount(vehicleList);

            Console.Write("{0,-15} {1}\n", "Type", "No. of Vehicles");

            foreach (var item in result)
            {
                Console.WriteLine("{0,-15} {1}", item.Key, item.Value);
            }
        }
    }
}
