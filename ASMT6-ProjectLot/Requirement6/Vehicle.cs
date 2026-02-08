using System;
using System.Collections.Generic;

namespace Requirement
{
    public class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;

        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public Vehicle() { }

        public Vehicle(string registrationNo, string name, string type, double weight)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
        }

        public static Vehicle CreateVehicle(string detail)
        {
            string[] parts = detail.Split(',');

            return new Vehicle(
                parts[0].Trim(),
                parts[1].Trim(),
                parts[2].Trim().Replace(" ", ""), 
                double.Parse(parts[3].Trim())
            );
        }

        public static SortedDictionary<string, int> TypeWiseCount(List<Vehicle> vehicleList)
        {
            SortedDictionary<string, int> result = new SortedDictionary<string, int>();

            foreach (Vehicle v in vehicleList)
            {
                if (result.ContainsKey(v.Type))
                    result[v.Type]++;
                else
                    result[v.Type] = 1;
            }

            return result;
        }
    }
}
