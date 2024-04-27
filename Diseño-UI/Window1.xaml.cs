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
using Diseño_UI.ServiceReference;
namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Service1Client _client = new Service1Client();
        public Window1()
        {
            InitializeComponent();
            dataGrid.ItemsSource = _client.mostrar_inventario();
        }
    }
}
