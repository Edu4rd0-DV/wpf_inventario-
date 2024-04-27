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
    /// Lógica de interacción para Presentacion_UI.xaml
    /// </summary>
    public partial class Presentacion_UI : MetroWindow
    {
        Service1Client _cliente = new Service1Client();
        presentacion _p = new presentacion();
        public Presentacion_UI(int v1)
        {
            InitializeComponent();
            dgpresentacion.ItemsSource = _cliente.mostrar_presentacion();
            if (v1 == 2)
            {
                btnactualizar.Visibility = Visibility.Hidden;
                btneliminar.Visibility = Visibility.Hidden;
            }
        }

        private void button_clo_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();
           
        }
        // agreagar----------------------------------------------------------
        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtnombre.Text != ""
                    )
                {

                    _p.nombre = txtnombre.Text;
                    int resultado = _cliente.agregar_presentacion(_p);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos Actualizados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgpresentacion.ItemsSource = _cliente.mostrar_presentacion();


                    }
                    else
                    {
                        MessageBox.Show("Error de actualizacion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Todos los Campos con un * deben ser llenados", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


            }
            catch(Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Mensaje para usuario: No se encontró el servicio" + "\n" +
                    "Mensaje para el desarrollador: " + mensaje,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        //actualizar------------------------------------------------------------
        private void btnactualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtnombre.Text != ""
                    )
                {

                    _p.nombre = txtnombre.Text;
                    int resultado = _cliente.actualizar_presentacion(_p);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos Actualizados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgpresentacion.ItemsSource = _cliente.mostrar_presentacion();


                    }
                    else
                    {
                        MessageBox.Show("Error de actualizacion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
        // elimainar-------------------------------------------------------------
        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgpresentacion.SelectedItem != null)
                {
                    MessageBoxResult msg = MessageBox.Show("Quieres eliminar?", "?", MessageBoxButton.YesNo);
                    if (msg == MessageBoxResult.Yes)
                    {

                        _cliente.eliminar_presentacion(_p);
                        
                        dgpresentacion.ItemsSource = _cliente.mostrar_presentacion();
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
        // selecionar del data grip---------------------------------------------
        private void dgpresentacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                _p = dgpresentacion.SelectedItem as presentacion;
                if (_p != null)
                {

                    txtnombre.Text = _p.nombre;
               


                }

                else
                {
                    MessageBox.Show("No hay registros para seleccionar");

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
        //limpiar----------------------------------------------------------------
        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtnombre.Clear();
        }
        // buscar---------------------------------------------------------------------
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtbuscar.Text != "")
                {

                    _p.nombre = txtbuscar.Text;
                    dgpresentacion.ItemsSource = _cliente.buscar_presentacion(_p);

                }
                else
                {
                    dgpresentacion.ItemsSource = _cliente.mostrar_presentacion();
                }
            }
            catch
            {
                //
            }
        }
    }
    

       
}
