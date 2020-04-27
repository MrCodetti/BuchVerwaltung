using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchVerwaltung
{
    class DBconn
    {
        static string con = @"Data Source=DESKTOP-0S31MOV\SQLKURS;" +
                            "Initial Catalog=dbBibliothek;" +
                            "Integrated Security=sspi;";

        public static SqlConnection cn = new SqlConnection(con);
    }
}
