using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OEMS
{
    public class global_variable
    {
        public static string con = "Data Source=DESKTOP-6DAVLBI\\MYCONNECTION;Initial Catalog=myTracker_DB;Integrated Security=True";

        public string getConnectionString()
        {
            return con;
        }
    }
}