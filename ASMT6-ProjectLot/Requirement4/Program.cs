using System.Security.Cryptography.X509Certificates;

namespace Requirement4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the no of vehicles");
            int n = int.Parse(Console.ReadLine());
             VehicleBO vehicleBO = new VehicleBO();
            Console.WriteLine("Enter the details of the vehicle (in the order of (registration no,name,type,weight,ticketNo,parkedTime,cost):");
            for (int i=0;i<n;i++)
            {
                String details = Console.ReadLine();
                Vehicle vehicle = Vehicle.CreateVehicle(details);
                vehicleBO.AddVehicleToParking(vehicle);
            }


            bool exit = false;
            Console.WriteLine("Enter a search type:");
            while (!exit)
            {
                Console.WriteLine("1.By Type");
                Console.WriteLine("2.By ParkedTime");

                int searchType = int.Parse(Console.ReadLine());

                switch (searchType)
                {
                    case 1:
                        Console.WriteLine("Enter the vehicle type:");
                        string type = Console.ReadLine();
                        List<Vehicle> vehiceByType= vehicleBO.FindVehicle(vehicleBO.vehicles, type);
                        if (vehiceByType.Count > 0)
                        {
                            
                            foreach (Vehicle vehicle in vehiceByType)
                            {
                                Console.WriteLine(vehicle);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No vehicles found of type " + type);
                        }
                        break;
                    case 2:
                       Console.WriteLine("Enter the parked time (in the format dd-MM-yyyy HH:mm:ss");
                        DateTime parkedTime = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm:ss", null);
                        List<Vehicle> vehiceByParkedTime = vehicleBO.FindVehicle(vehicleBO.vehicles, parkedTime);
                        if (vehiceByParkedTime.Count > 0)
                        {
                            foreach (Vehicle vehicle in vehiceByParkedTime)
                            {
                                Console.WriteLine(vehicle);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No vehicles found parked at " + parkedTime);
                        }
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choie");
                        break;
                }
            }
        }
    }
}
