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
using System.Threading;
using AForge.Video;
using AForge.Video.DirectShow;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using System.Windows.Shapes;
// Mahapps Metro
using MahApps.Metro.Controls;
//
using TestCamera;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using WebCam_Capture;
using Diseño_UI.ServiceReference;
namespace Diseño_UI
{
    /// <summary>
    /// Lógica de interacción para EmpleadoUI.xaml
    /// </summary>
    public partial class EmpleadoUI : MetroWindow, INotifyPropertyChanged
    {
        //Control y manipulación de imagen
        byte[] imagen;
        byte[] imagen2;
        BitmapDecoder bitCoder;
        //instancia del servicio
        Service1Client _cliente = new Service1Client();
        Empleado _emp = new Empleado();
        sexo _sex = new sexo();

        public EmpleadoUI()
        {
            InitializeComponent();
            dgempleado.ItemsSource = _cliente.mostrar_empleado();
            sexo();
            cargo();
            GetVideoDevices();


        }

        public void limpiar()
        {
            txtnombre1.Clear();
            txtapellido1.Clear();
            fecha_n = null;
            cbxsexo1.SelectedValue = null;
            cbxcargo1.SelectedValue = null;
            txtdui.Clear();
            txtNick.Clear();
            txtpass.Clear();
            txtpass2.Clear();
            imgUsuario.Source = new BitmapImage
           (new Uri("pack://application:,,,/img/empleado.png",
           UriKind.Absolute));
            txtRuta.Text = "Ruta de la imagen";
        }
        // GroupBox
        public void sexo()
        {
            cbxsexo1.ItemsSource = _cliente.mostrar_sexo();
            cbxsexo1.DisplayMemberPath = "nombre";
            cbxsexo1.SelectedValuePath = "id";

        }

        public void cargo()
        {
            cbxcargo1.ItemsSource = _cliente.mostrar_cargo();
            cbxcargo1.DisplayMemberPath = "nombre";
            cbxcargo1.SelectedValuePath = "id";

        }



        private void Btncloseeem_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();

        }

        private void Btncargo_mas_Click(object sender, RoutedEventArgs e)
        {
            gridoculto.Visibility = Visibility.Visible;
            gbCargo.Visibility = Visibility.Visible;
        }

        private void Btnsexo_mas_Click(object sender, RoutedEventArgs e)
        {
            gridoculto.Visibility = Visibility.Visible;
            gbsexo.Visibility = Visibility.Visible;
        }

        private void Btnsalircargo_Click(object sender, RoutedEventArgs e)
        {
            gridoculto.Visibility = Visibility.Hidden;
            gbCargo.Visibility = Visibility.Hidden;
        }

        private void Btnsalirsexo_Click(object sender, RoutedEventArgs e)
        {
            gridoculto.Visibility = Visibility.Hidden;
            gbsexo.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gridoculto.Visibility = Visibility.Hidden;
            gbbuscar_empleado.Visibility = Visibility.Hidden;
        }

        private void Btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            gridoculto.Visibility = Visibility.Visible;
            gbbuscar_empleado.Visibility = Visibility.Visible;
        }

        private void btnagregarFoto_Click(object sender, RoutedEventArgs e)
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
                        imgUsuario.Source = bitCoder.Frames[0];
                        txtRuta.Text = OD.FileName;
                    }
                }
                System.IO.FileStream fs;
                fs = new System.IO.FileStream(txtRuta.Text, System.IO.FileMode.Open);
                imagen = new byte[Convert.ToInt32(fs.Length.ToString())];
                fs.Read(imagen, 0, imagen.Length);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }
        }

        private void btnagregarE_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                if (txtpass.Password == txtpass2.Password)
                {
                    _emp.nombre = txtnombre1.Text;
                    _emp.apellido = txtapellido1.Text;
                    _emp.fecha_n = Convert.ToDateTime(fecha_n.SelectedDate);
                    _emp.sexo = Convert.ToInt32(cbxsexo1.SelectedValue);
                    _emp.dui = Convert.ToInt32(txtdui.Text);
                    _emp.cargo = Convert.ToInt32(cbxcargo1.SelectedValue);
                    _emp.foto = imagen;
                    _emp.nick = txtNick.Text;
                    _emp.pass = txtpass.Password;
                    int resultado = _cliente.agregar_empleado(_emp);
                    if (resultado > 0)
                    {
                        limpiar();
                        MessageBox.Show("Datos Guardados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgempleado.ItemsSource = _cliente.mostrar_empleado();



                    }
                    else
                    {
                        MessageBox.Show("Error de Guardado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("la contraseña no conside");
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
        #region
        private void dgempleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                _emp = dgempleado.SelectedItem as Empleado;
                if (_emp != null)
                {

                    txtnombre1.Text = _emp.nombre;
                    txtapellido1.Text = _emp.apellido;
                    fecha_n.SelectedDate = _emp.fecha_n;
                    cbxsexo1.SelectedValue = _emp.sexo;
                    txtdui.Text = Convert.ToString(_emp.dui);
                    cbxcargo1.SelectedValue = _emp.cargo;
                    ConvertirBitsImagen(_emp);
                    txtNick.Text = _emp.nick;
                    gridoculto.Visibility = Visibility.Hidden;
                    gbbuscar_empleado.Visibility = Visibility.Hidden;

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

        #endregion

        private void ConvertirBitsImagen(Empleado _usuario)
        {
            // stream de memoria
            MemoryStream _str = new MemoryStream();
            //_str le cargamos la imagen que esta guardada en la BD
            _str.Write(_usuario.foto, 0, _usuario.foto.Length);
            //regresamos el stream a la posicion 0 
            _str.Position = 0;
            //convertimos el stram a imagen
            System.Drawing.Image _img = System.Drawing.Image.FromStream(_str);
            //creamos un mapa de bits 
            BitmapImage biImagen = new BitmapImage();
            // stream de memoria
            MemoryStream str = new MemoryStream();
            //el primer stream guarda la imagen 
            //el segundo stream guardaremos esa imagen en el formato que queramos
            //comienza transformacion
            biImagen.BeginInit();
            //salvamos la imagen en el segundo stream
            _img.Save(str, System.Drawing.Imaging.ImageFormat.Jpeg);
            //colocamos el stream en la posicion inicial
            str.Seek(0, SeekOrigin.Begin);
            //cargamos al mapa de bits la imagen que esta en el stream
            biImagen.StreamSource = str;
            //termina transformacion
            biImagen.EndInit();
            //mostrar la imagen
            imgUsuario.Source = biImagen;
        }

        private void btnactualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (imgUsuario.Source != null)
                {
                    _emp.nombre = txtnombre1.Text;
                    _emp.apellido = txtapellido1.Text;
                    _emp.fecha_n = Convert.ToDateTime(fecha_n.SelectedDate);
                    _emp.sexo = Convert.ToInt32(cbxsexo1.SelectedValue);
                    _emp.dui = Convert.ToInt32(txtdui.Text);
                    _emp.cargo = Convert.ToInt32(cbxcargo1.SelectedValue);
                    _emp.foto = imagen;
                    _emp.nick = txtNick.Text;

                    int resultado = _cliente.actualizar_empleado(_emp);
                    if (resultado > 0)
                    {
                        limpiar();
                        MessageBox.Show("Datos  Actualizados", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgempleado.ItemsSource = _cliente.mostrar_empleado();


                    }
                    else
                    {
                        MessageBox.Show("Error de Guardado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }

            }
            catch
            {

            }
        }

        private void btnagregarE_Copy1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgempleado.SelectedItem != null)
                {
                    MessageBoxResult msg = MessageBox.Show("Quieres eliminar?", "?", MessageBoxButton.YesNo);
                    if (msg == MessageBoxResult.Yes)
                    {

                        _cliente.eliminar_empleado(_emp);
                        limpiar();
                        dgempleado.ItemsSource = _cliente.mostrar_empleado();
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
            }
        }

        private void btnagregarE1_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        /*catch (Exception ex)
        {
            var mensaje = ex.Message;
            MessageBox.Show("Mensaje para usuario: No se encontró el servicio" + "\n" +
                "Mensaje para el desarrollador: " + mensaje,
                "Error!",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

        }*/
        //}

        #region
        private IVideoSource _videoSource;
        public ObservableCollection<FilterInfo> VideoDevices { get; set; }

        public FilterInfo CurrentDevice
        {
            get { return _currentDevice; }
            set { _currentDevice = value; this.OnPropertyChanged("CurrentDevice"); }
        }
        private FilterInfo _currentDevice;

        private void video_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                BitmapImage bi;
                using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    bi = bitmap.ToBitmapImage();
                }
                bi.Freeze(); // avoid cross thread operations and prevents leaks
                Dispatcher.BeginInvoke(new ThreadStart(delegate { videoPlayer.Source = bi; }));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error on _videoSource_NewFrame:\n" + exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                StopCamera();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        private void GetVideoDevices()
        {
            VideoDevices = new ObservableCollection<FilterInfo>();
            foreach (FilterInfo filterInfo in new FilterInfoCollection(FilterCategory.VideoInputDevice))
            {
                VideoDevices.Add(filterInfo);
            }
            if (VideoDevices.Any())
            {
                CurrentDevice = VideoDevices[0];
            }
            else
            {
                MessageBox.Show("No video sources found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartCamera()
        {
            if (CurrentDevice != null)
            {
                _videoSource = new VideoCaptureDevice(CurrentDevice.MonikerString);
                _videoSource.NewFrame += video_NewFrame;
                _videoSource.Start();
            }
        }

        private void StopCamera()
        {
            if (_videoSource != null && _videoSource.IsRunning)
            {
                _videoSource.SignalToStop();
                _videoSource.NewFrame -= new NewFrameEventHandler(video_NewFrame);
            }
        }



        private void btnON_Click(object sender, RoutedEventArgs e)
        {
            StartCamera();
        }
        #endregion

        private void btnOFF_Click(object sender, RoutedEventArgs e)
        {
            StopCamera();
        }

        private void btnCaptura_Click(object sender, RoutedEventArgs e)
        {
            videoPhoto.Source = videoPlayer.Source;
        }
    }
}