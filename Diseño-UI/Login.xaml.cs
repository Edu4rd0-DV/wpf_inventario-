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
// Referemcia de Mahapps Metro
using MahApps.Metro.Controls;
using Diseño_UI.ServiceReference;
using System.Data;
using System.Data.SqlClient;
namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        Service1Client _cliente = new Service1Client();
        Empleado _emp = new Empleado();

        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
              
          
       
            if (txtusuario.Text != "" && txtpasss.Password != "")
            {
          
                _emp.nick = txtusuario.Text;
                _emp.pass = txtpasss.Password;
                _emp.cargo = 1;
          
                if (_cliente.validar_empleado(_emp) == 1)
                {
                    int v = 1;
                    this.Hide();
                    Menu_Gerente g = new  Menu_Gerente(v);
                    g.ShowDialog();



                }
                //-----------------------------------------------------------
                 else
       
                    _emp.nick = txtusuario.Text;
                    _emp.pass = txtpasss.Password;
                    _emp.cargo = 2;
                    if (_cliente.validar_empleado(_emp) == 1)
                    {
                        int v = 2;
                        this.Hide();
                        Menu_Empleado u = new  Menu_Empleado(v);
                        u.ShowDialog();



                    }



                    else
                    {
                        MessageBox.Show("usuario no valido", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            
            else
            {
                MessageBox.Show("no dejes espacios basios ", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
