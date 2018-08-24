using RETO2APP.VIEWS;
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

namespace RETO2APP
{
    public partial class PanelUsers : Window
    {
        public PanelUsers()
        {
            InitializeComponent();
        }

        private void Clientesmodule(object sender, RoutedEventArgs e)
        {
            Registrocliente clientesmodule = new Registrocliente();
            this.Close();
            App.Current.MainWindow = clientesmodule;
            clientesmodule.Show();
        }

        private void Catalogosmodule(object sender, RoutedEventArgs e)
        {
            ModuloCatalogos catalogos = new ModuloCatalogos();
            this.Close();
            App.Current.MainWindow = catalogos;
            catalogos.Show();
        }

        private void ProductosModule(object sender, RoutedEventArgs e)
        {
            Moduloproductos mod = new Moduloproductos();
            this.Close();
            App.Current.MainWindow = mod;
            mod.Show();
        }

        private void AsociarModule(object sender, RoutedEventArgs e)
        {
            ModuloAsociar asoc = new ModuloAsociar();
            this.Close();
            App.Current.MainWindow = asoc;
            asoc.Show();
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
