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
using System.ServiceModel;
using Diseño_UI.ServiceReference;
namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para Venta_UI.xaml
    /// </summary>
    public partial class Venta_UI : MetroWindow
    {
        Service1Client _cliente = new Service1Client();
        ventas _ventas = new ventas();
        public Venta_UI()
        {
            InitializeComponent();
            dgventas.ItemsSource = _cliente.mostrar_ventas();

        }

       

        

        private void btncloseeem_Copy1_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void txtBuscar_venta_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtBuscar_venta.Text != "")
                {

                    _ventas.correo = txtBuscar_venta.Text;
                    dgventas.ItemsSource = _cliente.buscar_ventas(_ventas);

                }
                else
                {
                    dgventas.ItemsSource = _cliente.mostrar_ventas();
                }
            }
            catch
            {
                MessageBox.Show("Soporte tecnico  numero :2222222");
            }
        }
    }
}
