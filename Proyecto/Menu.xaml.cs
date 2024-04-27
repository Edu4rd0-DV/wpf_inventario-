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
// mahapps metro
using MahApps.Metro.Controls;

namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Btnlsalir_Click(object sender, RoutedEventArgs e)
        {
            Login var = new Login();
            this.Close();
            var.ShowDialog();
        }

       
    }
}
