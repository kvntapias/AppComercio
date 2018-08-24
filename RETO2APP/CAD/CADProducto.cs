using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DTO;
using System.Collections.ObjectModel;

namespace CAD
{
    public class CADProducto
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        private static SqlConnection con = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private static SqlDataAdapter sda = new SqlDataAdapter();
        private SqlDataReader rdr;
        public CADProducto()
        {
            con.ConnectionString = cadenaConexion;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        //CREAR PRODUCTO
        public int crearProducto(Producto p)
        {
            int filas = 0;
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.CommandText = "createproducto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@imagen", p.imagen);
                cmd.Parameters.AddWithValue("@cantidad", p.cantidad);
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

        //OBTENER PRODUCTOS POR BUSQUEDA
        public ObservableCollection<Producto> Obtenerproductos(Producto p)
        {
            ObservableCollection<Producto> ListaProductos = new ObservableCollection<Producto>();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "searchproducto";
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Producto busqueda = new Producto(
                        (int)rdr["Idprod"],
                        (string)rdr["nombre"],
                        (string)rdr["imagen"],
                        (int)rdr["cantidad"]
                        );
                    ListaProductos.Add(busqueda);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return ListaProductos;
        }

        //CATALOGOS COMBOBOX
        public ObservableCollection<Catalogo> CargarCatalogosBox()
        {
            ObservableCollection<Catalogo> LoadBox = new ObservableCollection<Catalogo>();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "comboCatalog";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Catalogo cat = new Catalogo(
                        (int)rdr["Idcat"],
                        (string)rdr["nombre"]
                        );
                    LoadBox.Add(cat);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return LoadBox;
        }

        //SELECT DE TODOS LOS  PRODUCTOS 
        public ObservableCollection<Producto> GetAllProducts()
        {
            ObservableCollection<Producto> ListarProductos = new ObservableCollection<Producto>();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "readproducto";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Producto all = new Producto(
                        (int)rdr["Idprod"],
                        (string)rdr["nombre"],
                        (string)rdr["imagen"],
                        (int)rdr["cantidad"]);
                    ListarProductos.Add(all);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                
            }
            finally
            {
                con.Close();
            }
            return ListarProductos;
        }

        //ASOCIAR PRODUCTO A CATALOGO
        public int asociarProdToCatalog(int idProd, int idCat)
        {
            int filas = 0;
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.CommandText = "createrel";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Catal", idCat);
                cmd.Parameters.AddWithValue("@Prod", idProd);
                filas = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception )
            {
                throw;
            }
            return filas;
        }
    }
}
