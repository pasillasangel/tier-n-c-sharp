using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EN;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class VentasDAL
    {
        public int AgregarVenta(Ventas pEN)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _command = new SqlCommand("AGREGAR_VENTAS", _conn as SqlConnection);

            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@NOMBRE", pEN.Nombre));
            _command.Parameters.Add(new SqlParameter("@TOTAL_VENTAS", pEN.Total_Ventas));
            _command.Parameters.Add(new SqlParameter("@ESTADO", pEN.Estado));

            int resultado = _command.ExecuteNonQuery();
            _conn.Close();
            return resultado;

        }

        public List<Ventas> MostrarVentas()
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULTAR_VENTAS", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _command.ExecuteReader();
            List<Ventas> lista = new List<Ventas>();
            while (_reader.Read())
            {
                Ventas _ventas = new Ventas();
                _ventas.Id = _reader.GetInt32(0);
                _ventas.Nombre = _reader.GetString(1);
                _ventas.Total_Ventas = _reader.GetInt32(2);
                _ventas.Estado = _reader.GetString(3);
                lista.Add(_ventas);
            }
            _conn.Close();
            return lista;
        }

        public List<Ventas> MostrarVentasPorNombre(Ventas pEN)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _command = new SqlCommand("CONSULTAR_VENTAS_POR_NOMBRE", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@NOMBRE", pEN.Nombre));
            IDataReader _reader = _command.ExecuteReader();
            List<Ventas> lista = new List<Ventas>();
            while (_reader.Read())
            {
                Ventas _ventas = new Ventas();
                _ventas.Id = _reader.GetInt32(0);
                _ventas.Nombre = _reader.GetString(1);
                _ventas.Total_Ventas = _reader.GetInt32(2);
                _ventas.Estado = _reader.GetString(3);
                lista.Add(_ventas);
            }
            _conn.Close();
            return lista;
        }

        public int ModificarVenta(Ventas pEN)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _command = new SqlCommand("MODIFICAR_VENTAS", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@ID", pEN.Id));
            _command.Parameters.Add(new SqlParameter("@NOMBRE", pEN.Nombre));
            _command.Parameters.Add(new SqlParameter("@TOTAL_VENTAS", pEN.Total_Ventas));
            _command.Parameters.Add(new SqlParameter("@ESTADO", pEN.Estado));

            int resultado = _command.ExecuteNonQuery();
            _conn.Close();
            return resultado;

        }

        public int EliminarVentas(Ventas pEN)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _command = new SqlCommand("ELIMINAR_VENTAS", _conn as SqlConnection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@ID", pEN.Id));
            int resultado = _command.ExecuteNonQuery();
            _conn.Close();
            return resultado;
        }
    }
}
