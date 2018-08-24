using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace CAD
{
    public class CADCatalogo
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        private static SqlConnection con = new SqlConnection(cadenaConexion);
        private SqlCommand cmd = new SqlCommand();
        private static SqlDataAdapter sda = new SqlDataAdapter();
        public CADCatalogo()
        {
            con.ConnectionString = cadenaConexion;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
        }
        //Registrar catalogo
        public int registrarCatalogo(Catalogo c)
        {
            int filas = 0;
            try
            {
                if(!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.CommandText = "createcatalogo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@estado", c.estado);
                filas = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
                filas = -2;
            }
            return filas;
        }
        //Buscar catalogo por fecha y nombre
        public DataTable BuscarCatalogo(Catalogo c)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.CommandText = "searchcatalog";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fecha", c.fecha);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return dt;
        }
        //Actualizar catálogo
        public int actualizarCatalogo(Catalogo c)
        {
            int filas = 0;
            try
            {
                if(!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.CommandText = "updatecatalogo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Idcat",c.Id);
                cmd.Parameters.AddWithValue("@nombre",c.nombre);
                cmd.Parameters.AddWithValue("@estado",c.estado);
                filas = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
                filas = -2;
            }
            return filas;
        }
        //Traer 1 catalogo 
        public DataTable OneCatalog(int id) {
            DataTable dt = new DataTable();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.CommandText = "readcatalogo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idcat", id);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return dt;
        }
        //Eliminar catalogo
        public int eliminarCatalogo(Catalogo c)
        {
            int filas = 0;
            try
            {
                if(!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.CommandText = "deletecatalogo";
                cmd.Parameters.AddWithValue("@idcat",c.Id);
                filas = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return filas;
        }
    }
}
