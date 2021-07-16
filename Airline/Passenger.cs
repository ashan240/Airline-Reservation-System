using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    public class Passenger
    {
        public bool IsValidPassenger(string name)
        {
            if (name.Trim().Equals(""))
            {
                return false;
            }

            return true;
        }
    }
}
