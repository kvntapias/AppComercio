using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace CAD
{
    public class CADUsuario
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        private static SqlConnection con = new SqlConnection(cadenaConexion);
        private static SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter sda = new SqlDataAdapter();
        public CADUsuario()
        {
            con.ConnectionString = cadenaConexion;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public DataTable Login(Usuario u)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.CommandText = "loginuser";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@documento", u.documento);
                cmd.Parameters.AddWithValue("@contraseña", u.contraseña);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception e)
            {

                string error = e.Message;
            }

            return dt;
        }
        public int registrousuario(Usuario u)
        {
            int filas = 0;
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.CommandText = "createuser";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@documento", u.documento);
                cmd.Parameters.AddWithValue("@nombres", u.nombres);
                cmd.Parameters.AddWithValue("@apellidos", u.apellidos);
                cmd.Parameters.AddWithValue("@contraseña", u.contraseña);
                cmd.Parameters.AddWithValue("@telefono", u.telefono);
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
        public int updateusuario(Usuario u)
        {
            int filas = 0;
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "updateuser";
                cmd.Parameters.AddWithValue("@documento", u.documento);
                cmd.Parameters.AddWithValue("@contraseña", u.contraseña);
                cmd.Parameters.AddWithValue("@telefono", u.telefono);
                filas = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                con.Close();
            }
            return filas;
        }
        public DataTable searchAllUsers()
        {
            DataTable dt = new DataTable();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "readuser";
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
        public DataTable searchxDoc(Usuario u)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "searchxDoc";
                cmd.Parameters.AddWithValue("@documento", u.documento);
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
        public int deleteuser(Usuario u)
        {
            int filas = 0;
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "deleteuser";
                cmd.Parameters.AddWithValue("@documento", u.documento);
                filas = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                throw;
            }
            return filas;
        }
    }
}
