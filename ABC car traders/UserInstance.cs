using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_car_traders
{
    //class to retrieve and store username of the currently logged in user
    class UserInstance
    {
       static string username;
        public static string uname
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
    }
}
