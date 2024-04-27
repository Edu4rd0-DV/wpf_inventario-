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
using MahApps.Metro.Controls;
namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para Menu_Empleado.xaml
    /// </summary>
    public partial class Menu_Empleado : MetroWindow
    {
        public Menu_Empleado(int v)
        {
            InitializeComponent();

          this.v1 = v;
        }
        int v1;
        private void tile_venta_Click(object sender, RoutedEventArgs e)
        {
            Venta_UI v = new Venta_UI();

            v.ShowDialog();
        }

        private void tile_inventario_Click(object sender, RoutedEventArgs e)
        {
            Inventario i = new Inventario(v1);
           
            i.ShowDialog();
        }

        private void tile_producto1_Click(object sender, RoutedEventArgs e)
        {
            Productos p = new Productos();
            
            p.ShowDialog();
        }

        private void tile_provedor_Click(object sender, RoutedEventArgs e)
        {
            Proveedor_UI pro = new Proveedor_UI(v1);
           
            pro.ShowDialog();
        }

        private void tile_presentacion_Click(object sender, RoutedEventArgs e)
        {
            Presentacion_UI pre = new Presentacion_UI(v1);
            
            pre.ShowDialog();
        }

        private void tile_tipo_Click(object sender, RoutedEventArgs e)
        {
            Tipo_UI t = new Tipo_UI(v1);
           
            t.ShowDialog();
        }

        private void btnclosesalir_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.ShowDialog();
        }
    }
}
