using Microsoft.Win32;
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
using CAD;
using DTO;
using System.Data;
using System.Collections.ObjectModel;

namespace RETO2APP.VIEWS
{

    public partial class Moduloproductos : Window
    {
        string rutaimg;
        public Moduloproductos()
        {
            InitializeComponent();
            loadCatalogoBox();
        }
        public ObservableCollection<Producto> ProductoList; // Coleccion de productos.
        public ObservableCollection<Catalogo> ComboboxCatalogo;
        //Abrir formulario
        private void OpenForm(object sender, RoutedEventArgs e)
        {
            FormularioProductos.Visibility = Visibility;
            scroll.Visibility = Visibility.Hidden;
        }
        //Cerrar formulario
        private void CloseForm(object sender, RoutedEventArgs e)
        {
            FormularioProductos.Visibility = Visibility.Hidden;
            scroll.Visibility = Visibility.Visible;
        }
        //Nuevo producto
        private void crearProducto(object sender, RoutedEventArgs e)
        {
            int filas = 0;
            if (String.IsNullOrEmpty(txtNombre.Text)||
                String.IsNullOrEmpty(txtCantidad.Text)||
                String.IsNullOrEmpty(rutaimg)||
                String.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("No se permiten campos vacios");
            }
            else
            {
                int cant = Int32.Parse(txtCantidad.Text);
                if (cant < 0)
                {
                    MessageBox.Show("No se permiten numeros negativos");

                }
                else
                {
                    CADProducto con = new CADProducto();
                    Producto p = new Producto();
                    p.nombre = txtNombre.Text;
                    p.cantidad = cant;
                    p.imagen = rutaimg;
                    filas = con.crearProducto(p);
                    switch (filas)
                    {
                        case 1:
                            MessageBox.Show("Producto registrado");
                            clearData();
                            break;
                        case -2:
                            MessageBox.Show("Ya hay un producto con este nombre");
                            break;
                        default:
                            MessageBox.Show("Producto no registrado");
                            break;
                    }
                }
            }
        }
        //Metodo añadir imagen
        private void AddFoto(object sender, RoutedEventArgs e)
        {
            if (imgFoto.Source == null)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                BitmapImage b = new BitmapImage();
                string msj = "Seleccione imagen de producto";
                openFile.Title = msj;
                openFile.Filter = "Todos(*.*)Imagenes .jpg .png | *.jpg;*.gif;*.png;*.bmp";
                if (openFile.ShowDialog() == true)
                {
                    b.BeginInit();
                    b.UriSource = new Uri(openFile.FileName);
                    rutaimg = openFile.FileName;
                    imgFoto.Source = new BitmapImage(new Uri(rutaimg));
                    b.EndInit();
                    imgFoto.Stretch = Stretch.Fill;
                    imgFoto.Source = b;
                }
            }
            else
            {
                imgFoto.Source = null;
                rutaimg = null;
                imgFoto.Source = null;
            }
        }
        //Back menu
        private void Menu(object sender, RoutedEventArgs e)
        {
            PanelUsers back = new PanelUsers();
            App.Current.MainWindow = back;
            back.Show();
            this.Close();
        }
        //Buscar producto por nombre
        private void BuscarProducto(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBusqueda.Text))
            {
                MessageBox.Show("Ingrese un producto a buscar");
            }
            else
            {
                CADProducto con = new CADProducto();
                Producto p = new Producto();
                p.nombre = txtBusqueda.Text;
                ProductoList = con.Obtenerproductos(p);
                CardProd.ItemsSource = ProductoList;
            }
        }
        //Limpiar datos
        public void clearData()
        {
            txtNombre.Text = null;
            imgFoto.Source = null;
            txtCantidad.Text = null;
            txtBusqueda.Text = null;
        }

        private void loadCatalogoBox()
        {
            CADProducto con = new CADProducto();
            ComboboxCatalogo = con.CargarCatalogosBox();
            boxCatalogo.ItemsSource = ComboboxCatalogo;
        }
    }
}
