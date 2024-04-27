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
// mahapps metro
using MahApps.Metro.Controls;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using WebCam_Capture;


namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para Inventario.xaml
    /// </summary>
    public partial class Inventario : MetroWindow
    {
        byte[] imagen;
        byte[] imagen2;
        BitmapDecoder bitCoder;
        Service1Client _cliente = new Service1Client();
        Inventariob _inv = new  Inventariob();
        proveedor _p = new proveedor();

        public Inventario( int v)
        {
            InitializeComponent();
            dataGrid.ItemsSource = _cliente.mostrar_inventario();
            producto();
            proveedor();
            sexo();

            if (v == 2)
            {
                btnactualizar.Visibility = Visibility.Hidden;
                BtnEliminar.Visibility = Visibility.Hidden;
            }
          
        }
        // cmb producto  
        private void producto()
        {
            cmbproducto.ItemsSource = _cliente.mostrar_producto();
            cmbproducto.DisplayMemberPath = "nombre";
            cmbproducto.SelectedValuePath = "id";
        }
        private void proveedor()
        {
            cmbproveedor.ItemsSource = _cliente.mostrar_proveedor();
            cmbproveedor.DisplayMemberPath = "nombre";
            cmbproveedor.SelectedValuePath = "Id";
        }

        private   void sexo()
        {
            cmbsexo.ItemsSource = _cliente.mostrar_sexo();
            cmbsexo.DisplayMemberPath = "nombre";
            cmbsexo.SelectedValuePath = "id";
        }
        //cmb 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gbproveedor.Visibility = Visibility.Visible;
            ginventario.Visibility = Visibility.Visible;
        }

        private void Btnclosee_Click(object sender, RoutedEventArgs e)
        {
            gbproveedor.Visibility = Visibility.Hidden;
            ginventario.Visibility = Visibility.Hidden;
        }

       

        
        //boton guardar  
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           try
            {
                if (cmbproducto.SelectedValue!=null&&
                    txtprecio.Text!=""&&
                    cmbsexo.SelectedValue != null &&
                    txtcantidad.Text!=null&&
                    cmbproveedor.SelectedValue!=null&&
                    fecha_e.SelectedDate!=null

                    
                    ) {

                    if (txtUrl.Text != null)
                    {

                        _inv.id_producto = Convert.ToInt64(cmbproducto.SelectedValue);
                        _inv.Precio = Convert.ToDecimal(txtprecio.Text);
                        _inv.id_sexo = Convert.ToInt32(cmbsexo.SelectedValue);
                        _inv.Cantidad = Convert.ToInt64(txtcantidad.Text);
                        _inv.id_proveedor = Convert.ToInt64(cmbproveedor.SelectedValue);
                        _inv.fecha_e = Convert.ToString(fecha_e.SelectedDate);
                        _inv.imagen = imagen;
                        _inv.descripcion = txtdescripcion.Text;
                        int resultado = _cliente.agregar_inventario(_inv);
                        if (resultado > 0)
                        {
                            MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                            dataGrid.ItemsSource = _cliente.mostrar_inventario();


                        }

                        else
                        {
                            MessageBox.Show("Error de Guardado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                    else
                    {
                        txtUrl.Text = "../..img/produc.png";
                        System.IO.FileStream fs2;
                        fs2 = new System.IO.FileStream(txtUrl.Text, System.IO.FileMode.Open);
                        imagen2 = new byte[Convert.ToInt32(fs2.Length.ToString())];
                        //---------------------------------------------------------
                        fs2.Read(imagen2, 0, imagen2.Length);
                        _inv.id_producto = Convert.ToInt64(cmbproducto.SelectedValue);
                        _inv.Precio = Convert.ToDecimal(txtprecio.Text);
                        _inv.id_sexo = Convert.ToInt32(cmbsexo.SelectedValue);
                        _inv.Cantidad = Convert.ToInt64(txtcantidad.Text);
                        _inv.id_proveedor = Convert.ToInt64(cmbproveedor.SelectedValue);
                        _inv.fecha_e = Convert.ToString(fecha_e.SelectedDate);
                        _inv.imagen = imagen2;
                        int resultado = _cliente.agregar_inventario(_inv);
                        if (resultado > 0)
                        {
                            MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                            dataGrid.ItemsSource = _cliente.mostrar_inventario();


                        }

                        else
                        {
                            MessageBox.Show("Error de Guardado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
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

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _inv = dataGrid.SelectedItem as Inventariob;
            if (_inv != null)
            {
                cmbproducto.SelectedValue = _inv.id_producto;
                txtprecio.Text = Convert.ToString( _inv.Precio);
                cmbsexo.SelectedValue = _inv.id_sexo;
                txtcantidad.Text = Convert.ToString(_inv.Cantidad);
                cmbproveedor.SelectedValue = _inv.id_proveedor;
                fecha_e.Text = Convert.ToString(_inv.fecha_e);
                txtdescripcion.Text = _inv.descripcion;
                

            }
            else
            {

            }
        }

        private void btnactualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _inv.id_producto = Convert.ToInt64(cmbproducto.SelectedValue);
                _inv.Precio = Convert.ToDecimal(txtprecio.Text);
                _inv.id_sexo = Convert.ToInt32(cmbsexo.SelectedValue);
                _inv.Cantidad = Convert.ToInt64(txtcantidad.Text);
                _inv.id_proveedor = Convert.ToInt64(cmbproveedor.SelectedValue);
                _inv.fecha_e = Convert.ToString(fecha_e.SelectedDate);
                _inv.imagen = imagen;
                int resultado = _cliente.actualizar_inventario(_inv);
                if (resultado > 0)
                {
                    MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    dataGrid.ItemsSource = _cliente.mostrar_inventario();


                }
                else
                {
                    MessageBox.Show("Error de Guardado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItem != null)
                {
                    MessageBoxResult msg = MessageBox.Show("¿Quieres eliminar?",
                        "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (msg == MessageBoxResult.Yes)
                    {

                        int resultado = _cliente.eliminar_inventario(_inv);
                        if (resultado > 0)
                        {
                            MessageBox.Show("Datos Eliminados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                            dataGrid.ItemsSource = _cliente.mostrar_inventario();

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
        //agregar_proveedor
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtprove.Text != "" &&
                    txtcontacto.Text != "" &&
                    txtdireccion.Text != ""

                    )
                {
                    _p.nombre = txtprove.Text;
                    _p.contacto = txtcontacto.Text;
                    _p.direcion = txtdireccion.Text;
                    int resultado = _cliente.agregar_proveedor(_p);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtprove.Clear();
                        txtcontacto.Clear();
                        txtdireccion.Clear();
                        

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

        private void button_clo_Click(object sender, RoutedEventArgs e)
        {
          
            this.Hide();
           
        }

        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
          
            txtprecio.Clear();
            txtcantidad.Clear();
            cmbproveedor.Items.Clear();
                    
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtbuscar.Text != "")
                {

                    _inv.DataProducto = txtbuscar.Text;
                    dataGrid.ItemsSource = _cliente.buscar_inventario(_inv);

                }
                else
                {
                    dataGrid.ItemsSource = _cliente.mostrar_inventario();
                }
            }
            catch
            {
                //
            }
        }

        private void btnBuscarImagen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OD = new OpenFileDialog();
                OD.Filter = "Images jpg(*.jpg)|*.jpg|All Files(*.*)| *.*";
                if (OD.ShowDialog() == true)
                {
                    using (Stream stream = OD.OpenFile())
                    {
                        bitCoder =
                            BitmapDecoder.Create(stream,
                            BitmapCreateOptions.PreservePixelFormat,
                            BitmapCacheOption.OnLoad);
                       image.Source = bitCoder.Frames[0];
                        txtUrl.Text = OD.FileName;
                    }
                }
                System.IO.FileStream fs;
                fs = new System.IO.FileStream(txtUrl.Text, System.IO.FileMode.Open);
                imagen = new byte[Convert.ToInt32(fs.Length.ToString())];
                fs.Read(imagen, 0, imagen.Length);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }
        }
    }
}
