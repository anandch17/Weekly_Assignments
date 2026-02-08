using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Requirement4
{
    internal class VehicleBO
    {
       public  List<Vehicle> vehicles;
        public VehicleBO() {
            vehicles = new List<Vehicle>();
        }


        public void AddVehicleToParking(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }
        public List<Vehicle> FindVehicle(List<Vehicle> vehicles, string type)
        {
            return vehicles.Where(v => v.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Vehicle> FindVehicle(List<Vehicle> vehicles, DateTime parkedTime)
        {
            return vehicles.Where(v => v.Ticket.ParkedTime == parkedTime).ToList();
        }

      

    }


}
