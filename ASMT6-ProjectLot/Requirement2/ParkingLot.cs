using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement2
{
	public class ParkingLot
	{

		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private List<Vehicle> _vehicleList;

		public List<Vehicle> VehicleList
		{
			get { return _vehicleList; }
			set { _vehicleList = value; }
		}

		public ParkingLot() {
            _vehicleList = new List<Vehicle>();
            _vehicleList = _vehicleList ?? new List<Vehicle>();
        }

		


		public void AddVehicleToParking(Vehicle vehicle)
		{
			VehicleList.Add(vehicle);
		}

		public bool RemoveVehicleFromParking(string registrationNo)
		{
			bool exists = VehicleList.Any(v => v.RegistrationNo == registrationNo);

			if (exists)
			{
				VehicleList.RemoveAll(v => v.RegistrationNo == registrationNo);
				return true;
			}
			return false;
		}

		public void DisplayVehicles()
		{
			if (VehicleList.Count == 0)
			{
				Console.WriteLine("No vehicles in the parking lot.");
				return;
			}
			Console.WriteLine($"Vehicles in the {_name}:");
            Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}","Registration No", "Name", "Type", "Weight", "Ticket No");

            foreach (Vehicle v in VehicleList)
            {
                Console.WriteLine(
                "{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}",
                v.RegistrationNo,
                v.Name,
                v.Type,
                v.Weight,
                v.Ticket.TicketNo
                );
            }

        }

    }
}
