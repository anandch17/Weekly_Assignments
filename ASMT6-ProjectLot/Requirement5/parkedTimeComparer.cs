using System.Collections.Generic;

namespace Requirement5
{
    public class parkedTimeComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x == null || y == null)
                return 0;

            return x.Ticket.ParkedTime.CompareTo(y.Ticket.ParkedTime);
        }
    }
}
