using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO;
using CAD;
using System.Collections.ObjectModel;

namespace RETO2APP.VIEWS
{
    public partial class ModuloAsociar : Window
    {
        public ModuloAsociar()
        {
            InitializeComponent();
            LoadBoxProducto();
            LoadBoxCatalogo();
        }
        CADProducto con = new CADProducto();
        //Caja producto Seleccionar
        public ObservableCollection<Producto> ProductoList; // Coleccion de productos.
        private void LoadBoxProducto()
        {
            ProductoList = con.GetAllProducts();
            productoID.ItemsSource = ProductoList;
        }
        //Caja Catalogo Seleccionar
        public ObservableCollection<Catalogo> CatalogoList;
        private void LoadBoxCatalogo()
        {
            CatalogoList = con.CargarCatalogosBox();
            catalogoID.ItemsSource = CatalogoList;
        }
        //Evento asociar a catalogo
        private void AsignarCatalogo(object sender, RoutedEventArgs e)
        {
            if (catalogoID.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el catalogo");
            }
            if (productoID.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el producto");
            }
            else
            {
                int filas = 0;
                int prodID;
                bool result = int.TryParse(productoID.SelectedValue.ToString(), out prodID);

                int catID;
                bool result2 = int.TryParse(catalogoID.SelectedValue.ToString(), out catID);
                CADProducto con = new CADProducto();
                filas = con.asociarProdToCatalog(prodID, catID);
                if (filas > 0)
                {
                    MessageBox.Show("Categoria asignada");
                }
                else
                {
                    MessageBox.Show("Categoria no asignada");
                }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            PanelUsers back = new PanelUsers();
            App.Current.MainWindow = back;
            back.Show();
            this.Close();
        }
    }
}
