using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement5
{
    public class Vehicle:IComparable<Vehicle>
    {
        private string _registrationNo;

        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private Ticket _ticket;

        public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }



        public Vehicle() { }

        public Vehicle(string registrationNo, string name, string type, double weight, Ticket ticket)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }

        public override string ToString()
        {
            return string.Format(
              "{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}",
              RegistrationNo,
              Name,
              Type,
              Weight,
              Ticket.TicketNo);
        }

        public static Vehicle CreateVehicle(string detail)
        {
            string[] parts = detail.Split(',');
            if (parts.Length != 7)
            {
                throw new ArgumentException("Invalid detail format. Expected format: 'RegistrationNo,Name,Type,Weight,TicketNo,ParkedTime,Cost'");
            }
            string registrationNo = parts[0].Trim();
            string name = parts[1].Trim();
            string type = parts[2].Trim();
            double weight;
            if (!double.TryParse(parts[3].Trim(), out weight))
            {
                throw new ArgumentException("Invalid weight format. Weight should be a number.");
            }
            string ticketNo = parts[4].Trim();
            DateTime parkedTime = DateTime.ParseExact(parts[5].Trim(), "dd-MM-yyyy HH:mm:ss", null);

            double cost;
            if (!double.TryParse(parts[6].Trim(), out cost))
            {
                throw new ArgumentException("Invalid cost format. Weight should be a number.");
            }
            Ticket ticket = new Ticket
            {
                TicketNo = ticketNo,
                ParkedTime = parkedTime,
                Cost = cost
            };
            return new Vehicle(registrationNo, name, type, weight, ticket);
        }

        public int CompareTo(Vehicle? other)
        {
            if(other == null) return 1;
            return this.Weight.CompareTo(other.Weight);
        }
    }
}
