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
using Microsoft.Reporting.WinForms;
using Diseño_UI.ServiceReference;

namespace Diseño_UI.Reportes
{
    /// <summary>
    /// Lógica de interacción para Reporte_Productos.xaml
    /// </summary>
    public partial class Reporte_Productos : MetroWindow

       
    {
        Productos p = new Productos();
        Service1Client cliente = new Service1Client();
        public Reporte_Productos()
        {
            InitializeComponent();
          
        }
       
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            viewerInstance.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", cliente.mostrar_producto()));
            viewerInstance.SetDisplayMode(DisplayMode.PrintLayout);
            viewerInstance.ZoomMode = ZoomMode.Percent;
            viewerInstance.ZoomPercent = 100;
            viewerInstance.LocalReport.ReportPath = "..\\..\\Reportes\\ReportProductos.rdlc";
            viewerInstance.RefreshReport();
        }
    }
}
