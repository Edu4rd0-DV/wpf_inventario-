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
    /// Lógica de interacción para Menu_Gerente.xaml
    /// </summary>
    public partial class Menu_Gerente : MetroWindow
    {
        public Menu_Gerente(int v)
        {
            InitializeComponent();
            this.v1 = v;

        }
        int v1;
        private void img_reporte_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vReporte ver = new vReporte();
        
            ver.ShowDialog();
        }

        private void tile_venta_Click(object sender, RoutedEventArgs e)
        {
            Venta_UI v = new Venta_UI();
           
            v.ShowDialog();
        }

        private void tile_inventario_Click(object sender, RoutedEventArgs e)
        {
            Inventario inv = new Inventario(v1);
            
            inv.ShowDialog();
        }

        private void tile_producto1_Click(object sender, RoutedEventArgs e)
        {
            Productos prop = new Productos();
           
            prop.ShowDialog();
        }

        private void tile_presentacion_Click(object sender, RoutedEventArgs e)
        {
            Presentacion_UI pres = new Presentacion_UI(v1);
           
            pres.ShowDialog();
        }

        private void tile_tipo_Click(object sender, RoutedEventArgs e)
        {
            Tipo_UI t = new Tipo_UI(v1);
           
            t.ShowDialog();
        }

        private void tile_provedor_Click(object sender, RoutedEventArgs e)
        {
            Proveedor_UI prov = new Proveedor_UI(v1);
          
            prov.ShowDialog();
        }

        private void tile_empleado_Click(object sender, RoutedEventArgs e)
        {
            EmpleadoUI emp = new EmpleadoUI();
        
            emp.ShowDialog();
        }

        private void btnclosesalir_Click(object sender, RoutedEventArgs e)
        {
            Login ver = new Login();
            this.Hide();
            ver.ShowDialog();
        }
    }
}
