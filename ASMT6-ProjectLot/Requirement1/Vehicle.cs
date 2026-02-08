using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Requirement1
{
    public class Vehicle
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

		public Ticket GetTicket
		{
			get { return _ticket; }
			set { _ticket = value; }
        }


		public Vehicle()
		{

		}

		public Vehicle(string registrationNo, string name, string type, double weight,Ticket ticket)
		{
			_registrationNo = registrationNo;
			_name = name;
			_type = type;
			_weight = weight;
			_ticket = ticket;
		}


        public override bool Equals(object? obj)
        {
            Vehicle veh1=obj as Vehicle;
			if (obj == null)
				return false;
			else
				return _registrationNo==veh1._registrationNo && _name.ToLower()==veh1._name.ToLower();
        }

		public  override string ToString()
		{
			return $"Registration No:{_registrationNo}" +"\n"+
				$"Name:{_name}" + "\n" +
                $"Type:{_type}" + "\n" +
                $"Weight:{_weight:F1}" + "\n" +
                $"Ticket No:{_ticket.TicketNo}" + "\n" +
				$"Parked Time:{_ticket.ParkedTime}"+"\n"+
				$"Cost:{ _ticket.Cost}"+"\n";
        }


    }
}
