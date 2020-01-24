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
using System.Windows.Navigation;
using System.Windows.Shapes;
//Librerias usadas
//Para abrir ventanas y elegir archivos
using Microsoft.Win32;
//Librerias de NAudio para tomar una salida
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
//Threading
using System.Windows.Threading;

namespace Reproductor
{
    
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        DispatcherTimer timer;
        //Lector de archivos
        AudioFileReader reader;
        //Comunicacion con la tarjeta de audio expclusivo para salidas
        WaveOut output;


        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Tomo el tiempo y lo pone en la eatiqueta
            lblTiempoActual.Text = reader.CurrentTime.ToString().Substring(0, 8);
            PbReproduccion.Value = reader.CurrentTime.TotalSeconds;
            if (reader.CurrentTime.TotalSeconds > 0 && reader.CurrentTime.TotalSeconds <= 4)
                lbl1.Text = "Darkness locks me into this room";
            lbl1.Visibility = Visibility.Visible;
            if (reader.CurrentTime.TotalSeconds > 4 && reader.CurrentTime.TotalSeconds <= 6)
                lbl1.Text = "obo";

        }

        private void BtnReproducir_Click(object sender, RoutedEventArgs e)
        {
                
                    reader = new AudioFileReader(@"gallows-bell.mp3");
                    output = new WaveOut();
                    output.DeviceNumber = default;
                    output.PlaybackStopped += Output_PlaybackStopped;
                    output.Init(reader);
                    output.Play();
                    btnReproducir.Visibility = Visibility.Collapsed;
                    PbReproduccion.Maximum = reader.TotalTime.TotalSeconds;
                    lblTiempoTotal.Text = reader.TotalTime.ToString().Substring(0,8);
                    lblTiempoActual.Text = reader.CurrentTime.ToString().Substring(0, 8);
                    timer.Start();
                
        }

        private void Output_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            timer.Stop();
            reader.Dispose();
            output.Dispose();
        }
    }
}
