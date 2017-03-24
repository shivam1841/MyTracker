using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OEMS
{
    public class global_variable
    {
        public static string con = "Data Source=mytracker.database.windows.net;Initial Catalog=myTracker;Persist Security Info=True;User ID=harsh;Password=Admin@mytracker";

        public string getConnectionString()
        {
            return con;
        }
    }
}