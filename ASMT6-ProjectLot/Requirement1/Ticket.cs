using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement1
{
    public  class Ticket
    {
        private string _ticketNo;

        public string TicketNo
        {
            get { return _ticketNo; }
            set { _ticketNo = value; }
        }

        private DateTime _parkedTime;
            public DateTime ParkedTime
        {
            get { return _parkedTime; }
            set { _parkedTime= value; }
        }

        private Double _cost;
        public Double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }




        public Ticket()
        {

        }

        public Ticket(string ticketNo, DateTime parkedTime, double cost)
        {
            _ticketNo = ticketNo;
            _parkedTime = parkedTime;
            _cost = cost;
        }


        public override string ToString()
        {
            return $"TicketNo:{_ticketNo},ParkedTime:{_parkedTime},Cost:{_cost:F1}";
        }
    }
}
