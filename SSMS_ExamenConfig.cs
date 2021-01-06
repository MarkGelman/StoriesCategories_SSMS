using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30122020_SSMS_EXAMEN
{
    class SSMS_ExamenConfig
    {
        internal static SqlConnection connection;
        public static SqlConnection GetOpenConnection (string string_connection)
        {
            SqlConnection connection = new SqlConnection(string_connection);
            connection.Open();
            return connection;
        }
    }
}
