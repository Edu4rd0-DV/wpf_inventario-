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
    /// Lógica de interacción para Reporte_empleado.xaml
    /// </summary>
    public partial class Reporte_empleado : Window

        
    {
        Empleado em = new Empleado();
        Service1Client cliente = new Service1Client();
        public Reporte_empleado()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewerInstance.LocalReport.DataSources.Add(new ReportDataSource("DataSetE", cliente.mostrar_empleado()));
            viewerInstance.SetDisplayMode(DisplayMode.PrintLayout);
            viewerInstance.ZoomMode = ZoomMode.Percent;
            viewerInstance.ZoomPercent = 100;
            viewerInstance.LocalReport.ReportPath = "..\\..\\Reportes\\ReportEmpleado.rdlc";
            viewerInstance.RefreshReport();
        }
    }
}
