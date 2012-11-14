using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GameServer
{
    class database
    {
        SqlConnection con = new SqlConnection();
        public database()
        {
            con.ConnectionString = "server=localhost\\VOIDDATABASE;database=mmogameproject;user id=oguztecimer; password=dakmoriar4444;";
            con.Open();
        }
    }
}
