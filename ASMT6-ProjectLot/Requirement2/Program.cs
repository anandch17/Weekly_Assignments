namespace Requirement2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ParkingLot parkingLot=new ParkingLot();
            bool per = false;
            while (!per)
            {
                Console.WriteLine("Parking-Lot Menu");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Delete Vehicle");
                Console.WriteLine("3. Display Vehicles");
                Console.WriteLine("4. Exit");

                Console.WriteLine("Please Enter the Parking_Lot Name:");
                parkingLot.Name = Console.ReadLine();
                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the details of the vehicle (in the order of (registration no,name,type,weight,ticketNo,parkedTime,cost):");
                        String details = Console.ReadLine();
                        Vehicle vehicle = Vehicle.CreateVehicle(details);
                        parkingLot.AddVehicleToParking(vehicle);
                        Console.WriteLine("Vehicle successfully added");
                        break;
                    case 2:
                        Console.WriteLine("Enter the registration number of the vehicle to delete:");
                        string regNoToDelete = Console.ReadLine();
                        if (parkingLot.RemoveVehicleFromParking(regNoToDelete))
                        {
                            Console.WriteLine("Vehicle successfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Vehicle not found in parkinglot");
                        }
                        break;
                    case 3:

                        parkingLot.DisplayVehicles();
                        break;
                    case 4:
                        per = true;
                        break;
                }
            }
        }
    }
}
