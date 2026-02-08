using Requirement1;

namespace ProjectLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Vehicle> vehicle = new List<Vehicle> {
            // new Vehicle("TG-04-HH-9999", "Vijay", "Car", 1500, new Ticket("T2", DateTime.Now, 50)),
            // new Vehicle("TG-04-UB-1234", "Rahul", "Car", 1200, new Ticket("T1", DateTime.Now, 40)),
            // new Vehicle("TG-07-AB-9999", "Ajay", "Car", 1300, new Ticket("T3", DateTime.Now, 45)),
            //    };

            List<Vehicle> vehicle = new List<Vehicle>();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Enter the details of the vehicle {i+1} (in the order of (registration no,name,type,weight,ticketNo,parkedTime,cost):");
                String[] details = Console.ReadLine().Split(',');
                string registrationNo = details[0];
                string name = details[1];
                string type = details[2];
                string weight = details[3];
                string ticketNo = details[4];
                string parkedTime = details[5];
                string cost = details[6];
                vehicle.Add(new Vehicle(registrationNo, name, type, double.Parse(weight), new Ticket(ticketNo, DateTime.Parse(parkedTime), double.Parse(cost))));
            }

            int j = 0;
            foreach (Vehicle v in vehicle)
            {
                Console.WriteLine($"Vehicle {j + 1}:");
                    j++;
                Console.WriteLine(v);

            }
            Vehicle veh1=vehicle.ElementAt<Vehicle>(0);
            Vehicle veh2=vehicle.ElementAt<Vehicle>(1);
            if (veh1.Equals(veh2))
            {
                Console.WriteLine("Vehicle 1 is same as Vehicle 2");
            }
            else
            {
                Console.WriteLine("Vehicle 1 and Vehicle 2 are different");
            }
            ;
        }
    }
}