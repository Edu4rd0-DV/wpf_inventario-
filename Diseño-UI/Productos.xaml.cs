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
using System.Data;
using System.Data.SqlClient;
// Reerencia de Mahapps Metro
using MahApps.Metro.Controls;

namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : MetroWindow
    {
        Service1Client _cliente = new Service1Client();
        Producto _producto = new Producto();
        tipo _tipo = new tipo();
        presentacion _presentacion = new presentacion();


        public Productos()
        {
            InitializeComponent();
            dg_tipo.ItemsSource = _cliente.mostrar_producto();
            tipo();
            presentacion();

            
        }

        // metodos para combobox 
          private void tipo()
        {
            cmbtipo.ItemsSource = _cliente.mostrar_tipo();
            cmbtipo.DisplayMemberPath = "nombre";
            cmbtipo.SelectedValuePath = "id";
        }
        // cmbpresentacion
           private void presentacion()
        {
            cmbpresentacio.ItemsSource = _cliente.mostrar_presentacion();
            cmbpresentacio.DisplayMemberPath ="nombre";
            cmbpresentacio.SelectedValuePath ="id"; 
        }
        //limpiar
        public void limpiar()
        {
            txtproducto.Clear();
            
        }
        //botones
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gbtipo.Visibility = Visibility.Visible;
            gproducto.Visibility = Visibility.Visible;
        }

        private void Btn_gbpresentacion_Click(object sender, RoutedEventArgs e)
        {
            gbpresentacion.Visibility = Visibility.Visible;
            gproducto.Visibility = Visibility.Visible;
        }

        private void Btnclosee_Click(object sender, RoutedEventArgs e)
        {
            gbtipo.Visibility = Visibility.Hidden;
            gproducto.Visibility = Visibility.Hidden;
        }

        private void Btnclosee1_Click(object sender, RoutedEventArgs e)
        {
            gbpresentacion.Visibility = Visibility.Hidden;
            gproducto.Visibility = Visibility.Hidden;
        }
        //guardar
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtproducto.Text != "" &&
                    cmbtipo.SelectedValue != null &&
                    cmbpresentacio.SelectedValue != null

                    )
                {
                    _producto.nombre = txtproducto.Text;
                     _producto.id_tipo=Convert.ToInt64(cmbtipo.SelectedValue) ;
                    _producto.id_presentacion = Convert.ToInt64(cmbpresentacio.SelectedValue) ;
                    int resultado = _cliente.agregar_producto(_producto);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dg_tipo.ItemsSource = _cliente.mostrar_producto();
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
        // datagrid producto 
        private void dg_tipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _producto= dg_tipo.SelectedItem as  Producto;
            if (_producto != null)
            {
                txtproducto.Text = _producto.nombre;
                cmbtipo.SelectedValue = _producto.id_tipo;
                cmbpresentacio.SelectedValue = _producto.id_presentacion;

            }
            else
            {

            }
        }
        // boton actualizar
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtproducto.Text != "" &&
                     cmbtipo.SelectedValue != null &&
                     cmbpresentacio.SelectedValue !=null
             )


                {
                    _producto.nombre = txtproducto.Text;
                    _producto.id_tipo = Convert.ToInt64(cmbtipo.SelectedValue);
                    _producto.id_presentacion = Convert.ToInt64(cmbpresentacio.SelectedValue);
                

                    int resultado = _cliente.actualizar_producto(_producto);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dg_tipo.ItemsSource = _cliente.mostrar_producto();



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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dg_tipo.SelectedItem != null)
                {
                    MessageBoxResult msg = MessageBox.Show("¿Quieres eliminar?",
                        "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (msg == MessageBoxResult.Yes)
                    {
                      
                        int resultado = _cliente.eliminar_producto(_producto);
                        if (resultado > 0)
                        {
                            MessageBox.Show("Datos Eliminados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                            dg_tipo.ItemsSource = _cliente.mostrar_producto(); 

                        }
                    }
                    if (msg == MessageBoxResult.No)
                    {
                        MessageBox.Show("Eliminacion cancelada");
                    }
                }
                else
                {

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
        // agregar  tipo 
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txttipo.Text != "" 
                

                    )
                {
                    _tipo.nombre = txttipo.Text;
                  
                    int resultado = _cliente.agregar_tipo(_tipo);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        txttipo.Clear();
                        tipo();
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
        // agregar tipo
        private void btnagregartipo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtpresentacion.Text != ""


                    )
                {
                    _presentacion.nombre = txtpresentacion.Text;

                    int resultado = _cliente.agregar_presentacion(_presentacion);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtpresentacion.Clear();
                        presentacion();

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

        private void button_c_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
           
        }
        //buscar------------------------------------------------------------
        private void txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtbuscar.Text != "")
                {

                    _producto.nombre = txtbuscar.Text;
                    dg_tipo.ItemsSource = _cliente.buscar_producto(_producto);

                }
                else
                {
                    dg_tipo.ItemsSource = _cliente.mostrar_producto();
                }
            }
            catch
            {
                //
            }
        }
    }
}
