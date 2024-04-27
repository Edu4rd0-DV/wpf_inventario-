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
// mahappsmetro
using MahApps.Metro.Controls;
using Diseño_UI.ServiceReference;


namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para vReporte.xaml
    /// </summary>
    public partial class vReporte : MetroWindow
    {
        public vReporte()
        {
            InitializeComponent();
        }

        private void tile_reporteproductos_Click(object sender, RoutedEventArgs e)
        {
            Reportes.Reporte_Productos rp = new Reportes.Reporte_Productos();
            
            rp.ShowDialog();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            Reportes.Reporte_Inventario ri = new Reportes.Reporte_Inventario();
            
            
            ri.ShowDialog();
        }

        private void img_salir_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            this.Hide();
      
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            Reportes.Reporte_empleado ep = new Reportes.Reporte_empleado();

            ep.ShowDialog();
        }

        private void txtproducto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
