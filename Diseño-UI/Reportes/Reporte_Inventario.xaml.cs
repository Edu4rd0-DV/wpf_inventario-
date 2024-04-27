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
using Microsoft.Reporting.WinForms;

namespace Diseño_UI.Reportes
{
    /// <summary>
    /// Lógica de interacción para Reporte_Inventario.xaml
    /// </summary>
    public partial class Reporte_Inventario : Window
    {

        Inventariob inv = new Inventariob();
        Service1Client cliente = new Service1Client();
        public Reporte_Inventario()
        {
            InitializeComponent();
        }

        

        private void reporteinventario_Loaded(object sender, RoutedEventArgs e)
        {
            viewerInstance.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", cliente.mostrar_inventario()));
            viewerInstance.SetDisplayMode(DisplayMode.PrintLayout);
            viewerInstance.ZoomMode = ZoomMode.Percent;
            viewerInstance.ZoomPercent = 100;
            viewerInstance.LocalReport.ReportPath = "..\\..\\Reportes\\ReportInventarios.rdlc";
            viewerInstance.RefreshReport();
        }
    }
}
