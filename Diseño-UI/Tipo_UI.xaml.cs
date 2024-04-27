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


namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para Tipo_UI.xaml
    /// </summary>
    public partial class Tipo_UI : MetroWindow
    {
        Service1Client _cliente = new Service1Client();
        tipo _tp = new tipo();
        public Tipo_UI(int v1)
        {
            InitializeComponent();
            dgTipo.ItemsSource = _cliente.mostrar_tipo();
            if (v1 == 2)
            {
                btnactualizar.Visibility = Visibility.Hidden;
                btneliminar.Visibility = Visibility.Hidden;
            }
        }
        public void limpiar()
        {
            txtNombre.Clear();
        }
        // agregar tipo 
        private void txtagregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNombre.Text != "" 
              

                    )
                {
                    _tp.nombre = txtNombre.Text;
                 

                    int resultado = _cliente.agregar_tipo(_tp);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgTipo.ItemsSource = _cliente.mostrar_proveedor();
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
        // actualizar_tipo
        private void btnactualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNombre.Text != "" 

                    )
                {
                    _tp.nombre = txtNombre.Text;
          

                    int resultado = _cliente.actualizar_tipo(_tp);
                    if (resultado > 0)
                    {

                        MessageBox.Show("Datos Actualizados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgTipo.ItemsSource = _cliente.mostrar_tipo();
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
        // eliminar_tipo
        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgTipo.SelectedItem != null)
                {
                    MessageBoxResult msg = MessageBox.Show("Quieres eliminar?", "?", MessageBoxButton.YesNo);
                    if (msg == MessageBoxResult.Yes)
                    {

                        _cliente.eliminar_tipo(_tp);
                        limpiar();
                        dgTipo.ItemsSource = _cliente.mostrar_proveedor();
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
        //limpiar
        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }
        // datagrid tipo
        private void dgTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                _tp = dgTipo.SelectedItem as tipo;
                if (_tp != null)
                {

                    txtNombre.Text = _tp.nombre;
          


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
        //Buscar_tipo 
        private void txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtbuscar.Text != "")
                {

                    _tp.nombre = txtbuscar.Text;
                   dgTipo.ItemsSource = _cliente.buscar_tipo(_tp);

                }
                else
                {
                    dgTipo.ItemsSource = _cliente.mostrar_tipo();
                }
            }
            catch
            {
                //
            }
        }

        private void button_clo_Click(object sender, RoutedEventArgs e)
        {
      
            this.Hide();
         
        }
    }
}
