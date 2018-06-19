using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class DBCommon
    {
        private static string Conn = @"Data Source=DESKTOP-367K99T\SQLEXPRESS; Initial Catalog=Ventas; Integrated Security=True";

        public static IDbConnection Conexion()
        {
            return new SqlConnection(Conn);
        }

        public static IDbCommand ObtenerComando(string pComando, IDbConnection pCnn)
        {
            return new SqlCommand(pComando, pCnn as SqlConnection);
        }
    }
}
