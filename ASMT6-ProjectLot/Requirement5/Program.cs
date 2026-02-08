namespace Requirement5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of the vehicles:");
            int n = int.Parse(Console.ReadLine());

            List<Vehicle> vehicleList = new List<Vehicle>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                vehicleList.Add(Vehicle.CreateVehicle(input));
            }

            Console.WriteLine("Enter a type to sort:");
            Console.WriteLine("1.Sort by weight");
            Console.WriteLine("2.Sort by parked time");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                vehicleList.Sort(); // uses IComparable (Weight)
            }
            else if (choice == 2)
            {
                vehicleList.Sort(new parkedTimeComparer());
            }
            if(choice != 1 && choice != 2)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Console.WriteLine(
                "{0,-15}{1,-10}{2,-12}{3,-7:F1}{4}",
                "Registration No", "Name", "Type", "Weight", "Ticket No"
            );

            foreach (Vehicle v in vehicleList)
            {
                Console.WriteLine(v);
            }
        }
    }
}
