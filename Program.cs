using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30122020_SSMS_EXAMEN
{
    class Program
    {
        static void Main(string[] args)
        {
            string string_connection = "Data Source=.;Database = 30122020_EXAMENSQL;Integrated Security=True";
            SqlConnection connection =SSMS_ExamenConfig.GetOpenConnection(string_connection);
            connection.Close();
        }
    }
}
