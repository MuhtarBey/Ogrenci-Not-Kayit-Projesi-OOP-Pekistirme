using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FacadeLayer
{
    public class ConnectionClass
    {
        public static SqlConnection cn = new SqlConnection(@"Data Source=MERTMURAT\SQLEXPRESS;Initial Catalog=OOP;Integrated Security=True");
    }
}
