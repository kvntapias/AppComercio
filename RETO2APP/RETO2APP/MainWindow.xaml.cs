using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CAD;
using DTO;
using RETO2APP.VIEWS;

namespace RETO2APP
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDocumento.Text))
            {
                MessageBox.Show("Ingrese el documento");
            }
            if (String.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Ingrese la contarseña");
            }
            else
            {
                DataTable dt = new DataTable();
                CADUsuario con = new CADUsuario();
                Usuario u = new Usuario();
                u.documento = txtDocumento.Text;
                u.contraseña = txtContraseña.Text;
                dt = con.Login(u);
                if (dt.Rows.Count > 0)
                {
                    PanelUsers panel = new PanelUsers();
                    this.Close();
                    App.Current.MainWindow = panel;
                    panel.Show();

                }
                else
                {
                    MessageBox.Show("Usuario/Contraseña Incorrectos");
                }
            }
        }
    }
}
