using Control_Pagos.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Pagos.Controlador
{
    class CampañasController
    {
        CRMBD conexion = new CRMBD();
     
        public SqlCommand comando = new SqlCommand();
        public DataTable Mostrarcampañas()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "[SPVerCampañas]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            SqlDataAdapter ad = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            ad.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
            
        }
        public DataTable MostrarDatosCRM()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "[SPVerCRM]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            SqlDataAdapter ad = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            ad.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
            
        }
        public DataTable MostrarcampañasXID(string Asignado_A)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "[SPVerCampañasXCliente]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@Asignado_A", Asignado_A);
            SqlDataAdapter ad = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            ad.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
            
        }
        public bool GuardarColumnasSinNombre(string Ruta, char Delimitador)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SPGuardarDatosSinColumnas";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Ruta", Ruta);
                comando.Parameters.AddWithValue("@Delimitador", Delimitador);
                comando.ExecuteNonQuery();
                conexion.CerrarConexion();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

            return true;
        }
    }
}
