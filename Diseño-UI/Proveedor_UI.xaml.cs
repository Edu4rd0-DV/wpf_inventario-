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
using Diseño_UI.ServiceReference;
using System.Threading;


namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para Proveedor_UI.xaml
    /// </summary>
    public partial class Proveedor_UI : MetroWindow
    {
        Service1Client _cliente = new Service1Client();
        proveedor _prov = new proveedor();
  
        public Proveedor_UI(int v1)
        {
            
            InitializeComponent();
            dgproveedor.ItemsSource = _cliente.mostrar_proveedor();

            if (v1 == 2)
            {
                btnProveedorActualizar.Visibility = Visibility.Hidden;
                 btnEliminar.Visibility = Visibility.Hidden;
            }

        }

        public void limpiar()
        {
            txtnombre.Clear();
            txtcontacto.Clear();
            txtdirrecion.Clear();
        }
        //agregar_
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtnombre.Text != "" &&
                    txtcontacto.Text !="" &&
                    txtdirrecion.Text != ""

                    )
                {
                    _prov.nombre = txtnombre.Text;
                    _prov.contacto = txtcontacto.Text;
                    _prov.direcion = txtdirrecion.Text;
   
                    int resultado = _cliente.agregar_proveedor(_prov);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgproveedor.ItemsSource = _cliente.mostrar_proveedor();
                        limpiar();

                    }
                    else
                    {
                        MessageBox.Show("Error de Guardado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Todos los Campos con un * deben ser llenados", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


            }

            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Mensaje para usuario: No se encontró el servicio" + "\n" +
                    "Mensaje para el desarrollador: " + mensaje,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

            }
        }
        // buscador
        private void txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtbuscar.Text != "")
                {
          
                    _prov.nombre = txtbuscar.Text;
                    dgproveedor.ItemsSource = _cliente.buscar_proveedor(_prov);
                
                }
                else
                {
                    dgproveedor.ItemsSource = _cliente.mostrar_proveedor();
                }
            }
            catch
            {
                //
            }
        }
        // cerrar
        private void button_clo_Click(object sender, RoutedEventArgs e)
        {
   
            this.Hide();
        
        }
        //datagrid
        private void dgproveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                _prov = dgproveedor.SelectedItem as proveedor;
                if (_prov != null)
                {

                    txtnombre.Text = _prov.nombre;
                    txtcontacto.Text = _prov.contacto;
                     txtdirrecion.Text = _prov.direcion;

         
                }

                else
                {
                    MessageBox.Show("No hay registros para seleccionar");
                  
                }
            }
            catch (Exception ex)
            {

            }
        }
        //Actualizar
        private void btnProveedorActualizar_Click(object sender, RoutedEventArgs e)
        {
             
            try
            {
                if (txtnombre.Text != "" &&
                    txtcontacto.Text != "" &&
                    txtdirrecion.Text != ""

                    )
                {
                    _prov.nombre = txtnombre.Text;
                    _prov.contacto = txtcontacto.Text;
                    _prov.direcion = txtdirrecion.Text;

                    int resultado = _cliente.actualizar_proveedor(_prov);
                    if (resultado > 0)
                    {
                   
                        MessageBox.Show("Datos Actualizados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgproveedor.ItemsSource = _cliente.mostrar_proveedor();
                        limpiar();

                    }
                    else
                    {
                        MessageBox.Show("Error de Guardado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Todos los Campos con un * deben ser llenados", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


            }

            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Mensaje para usuario: No se encontró el servicio" + "\n" +
                    "Mensaje para el desarrollador: " + mensaje,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

            }
        }
        //eliminar
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgproveedor.SelectedItem != null)
                {
                    MessageBoxResult msg = MessageBox.Show("Quieres eliminar?", "?", MessageBoxButton.YesNo);
                    if (msg == MessageBoxResult.Yes)
                    {

                        _cliente.eliminar_proveedor(_prov);
                        limpiar();
                         dgproveedor.ItemsSource = _cliente.mostrar_proveedor();
                        MessageBox.Show("Datos Eliminados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    if (msg == MessageBoxResult.No)
                    {
                        MessageBox.Show("No se Elimino", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Mensaje para usuario: No se encontró el servicio" + "\n" +
                    "Mensaje para el desarrollador: " + mensaje,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// AGREGAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtnombre.Text != "" &&
                    txtcontacto.Text != "" &&
                    txtdirrecion.Text != ""

                    )
                {
                    _prov.nombre = txtnombre.Text;
                    _prov.contacto = txtcontacto.Text;
                    _prov.direcion = txtdirrecion.Text;

                    int resultado = _cliente.agregar_proveedor(_prov);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgproveedor.ItemsSource = _cliente.mostrar_proveedor();
                        limpiar();

                    }
                    else
                    {
                        MessageBox.Show("Error de Guardado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Todos los Campos con un * deben ser llenados", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


            }

            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Mensaje para usuario: No se encontró el servicio" + "\n" +
                    "Mensaje para el desarrollador: " + mensaje,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

            }
        }
    }
}
