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
            if (reader.CurrentTime.TotalSeconds > 2 && reader.CurrentTime.TotalSeconds < 5)
                lbl1.Text = "Darkness locks me into this room";
            lbl1.Visibility = Visibility.Visible;
            if (reader.CurrentTime.TotalSeconds >= 5 && reader.CurrentTime.TotalSeconds < 8)
                lbl1.Text = "The air I breathe has never felt so cold";
            if (reader.CurrentTime.TotalSeconds >= 8 && reader.CurrentTime.TotalSeconds < 11)
                lbl1.Text = "And I'm losing hold of everything I had";
            if (reader.CurrentTime.TotalSeconds >= 11 && reader.CurrentTime.TotalSeconds <= 15)
                lbl1.Text = "So I'll rock myself to sleep";
            if (reader.CurrentTime.TotalSeconds > 15 && reader.CurrentTime.TotalSeconds <18 )
                lbl1.Text = "Her beautiful smile was always just for him";
            if (reader.CurrentTime.TotalSeconds >= 18 && reader.CurrentTime.TotalSeconds <21)
                lbl1.Text = "Every corner of her heart was filled with her love for him";
            if (reader.CurrentTime.TotalSeconds >=21  && reader.CurrentTime.TotalSeconds < 24)
                lbl1.Text = "Even when the time would come to say goodbye";
            if (reader.CurrentTime.TotalSeconds > 24 && reader.CurrentTime.TotalSeconds < 27)
                lbl1.Text = "This is what she'd say:";
            if (reader.CurrentTime.TotalSeconds >= 27 && reader.CurrentTime.TotalSeconds <30)//Dos veces
                lbl1.Text = "There's nothing to cry for I want you to know that";
            if (reader.CurrentTime.TotalSeconds >= 30 && reader.CurrentTime.TotalSeconds <34)//dos  veces
                lbl1.Text = "As long as it's you, this pain couldn't hurt me";
            if (reader.CurrentTime.TotalSeconds >= 34 && reader.CurrentTime.TotalSeconds <37)//dos veces
                lbl1.Text = "No reason to regret, I'll always be waiting for you";
            if (reader.CurrentTime.TotalSeconds >=37 && reader.CurrentTime.TotalSeconds < 40)//tres veces
                lbl1.Text = "My love Oh";
            if (reader.CurrentTime.TotalSeconds >= 40 && reader.CurrentTime.TotalSeconds < 44)//dos veces
                lbl1.Text = "It'll be alright I want you to know that";
            if (reader.CurrentTime.TotalSeconds >= 44 && reader.CurrentTime.TotalSeconds < 47)//dos veces
                lbl1.Text = "I'll always believe in the truth of your words";
            if (reader.CurrentTime.TotalSeconds >= 47 && reader.CurrentTime.TotalSeconds <50)
                lbl1.Text = "The only thing unreal was";
            if (reader.CurrentTime.TotalSeconds >= 50 && reader.CurrentTime.TotalSeconds <54)
                lbl1.Text = "my place in your heart";
            if (reader.CurrentTime.TotalSeconds >54 && reader.CurrentTime.TotalSeconds < 64)
                lbl1.Text = " ";

            if (reader.CurrentTime.TotalSeconds >= 64 && reader.CurrentTime.TotalSeconds <67)
                lbl1.Text = "She could feel his words wrap around her neck";
            if (reader.CurrentTime.TotalSeconds >= 67 && reader.CurrentTime.TotalSeconds < 71)
                lbl1.Text = "Her very last breath was swallowed into silence";
            if (reader.CurrentTime.TotalSeconds >= 71 && reader.CurrentTime.TotalSeconds < 74)
                lbl1.Text = "And everything they had together fell away";
            if (reader.CurrentTime.TotalSeconds >= 74 && reader.CurrentTime.TotalSeconds < 77)
                lbl1.Text = "This is how their story ends";
            if (reader.CurrentTime.TotalSeconds >=77 && reader.CurrentTime.TotalSeconds < 81)
                lbl1.Text = "Surrounded by an iron barricade";
            if (reader.CurrentTime.TotalSeconds >= 81 && reader.CurrentTime.TotalSeconds < 84)
                lbl1.Text = "Gazing at the light with eyes of lead";
            if (reader.CurrentTime.TotalSeconds >=84  && reader.CurrentTime.TotalSeconds < 87)
                lbl1.Text = "Even after all the time gone by";
            if (reader.CurrentTime.TotalSeconds >=87  && reader.CurrentTime.TotalSeconds <91)
                lbl1.Text = "This is what he'd say:";
            if (reader.CurrentTime.TotalSeconds >= 91 && reader.CurrentTime.TotalSeconds <93)
                lbl1.Text = "I look at these hands that are stained with blood and";
            if (reader.CurrentTime.TotalSeconds >=93 && reader.CurrentTime.TotalSeconds < 96)
                lbl1.Text = "They'll never bring back all the things that they took";
            //aqui me quede
            if (reader.CurrentTime.TotalSeconds >= 96 && reader.CurrentTime.TotalSeconds < 100)
                lbl1.Text = "So I won't turn back, I'll find you again someday";
            if (reader.CurrentTime.TotalSeconds >= 100 && reader.CurrentTime.TotalSeconds <103)
                lbl1.Text = "I know oh";
            if (reader.CurrentTime.TotalSeconds >= 103 && reader.CurrentTime.TotalSeconds < 106)
                lbl1.Text = "If only the tears would erase all the memories";
            if (reader.CurrentTime.TotalSeconds >= 106 && reader.CurrentTime.TotalSeconds < 109)
                lbl1.Text = "Then maybe I'd learn to fight all these fears";
            if (reader.CurrentTime.TotalSeconds >= 109 && reader.CurrentTime.TotalSeconds < 113)
                lbl1.Text = "Won't hesitate, won't run away";
            if (reader.CurrentTime.TotalSeconds >=113 && reader.CurrentTime.TotalSeconds < 116)
                lbl1.Text = "These are things I'm scared to say...";
            if (reader.CurrentTime.TotalSeconds >=116 && reader.CurrentTime.TotalSeconds < 143)
                lbl1.Text = " ";

            if (reader.CurrentTime.TotalSeconds >= 143  && reader.CurrentTime.TotalSeconds < 146)
                lbl1.Text = "As he is standing in light that is fading";
            if (reader.CurrentTime.TotalSeconds >=146  && reader.CurrentTime.TotalSeconds < 149)
                lbl1.Text = "He's feeling the trembling beat of his heart";
            if (reader.CurrentTime.TotalSeconds >= 149 && reader.CurrentTime.TotalSeconds < 153)
                lbl1.Text = "And he remembers the sound of her very last words";
            if (reader.CurrentTime.TotalSeconds >=153 && reader.CurrentTime.TotalSeconds < 155)
                lbl1.Text = "Again";
            if (reader.CurrentTime.TotalSeconds > 153 && reader.CurrentTime.TotalSeconds < 155)
                lbl1.Text = " ";
            if (reader.CurrentTime.TotalSeconds > 155 && reader.CurrentTime.TotalSeconds < 156)
                lbl1.Text = "Again";
            if (reader.CurrentTime.TotalSeconds >= 156 && reader.CurrentTime.TotalSeconds < 159)//Dos veces
                lbl1.Text = "There's nothing to cry for I want you to know that";
            if (reader.CurrentTime.TotalSeconds >=159 && reader.CurrentTime.TotalSeconds < 162)//dos  veces
                lbl1.Text = "As long as it's you, this pain couldn't hurt me";
            if (reader.CurrentTime.TotalSeconds >= 162 && reader.CurrentTime.TotalSeconds < 166)//dos veces
                lbl1.Text = "No reason to regret, I'll always be waiting for you";
            if (reader.CurrentTime.TotalSeconds >= 166 && reader.CurrentTime.TotalSeconds < 168)//tres veces
                lbl1.Text = "My love";
            if (reader.CurrentTime.TotalSeconds >168 && reader.CurrentTime.TotalSeconds < 169)//tres veces
                lbl1.Text = "My love";
            if (reader.CurrentTime.TotalSeconds >= 169 && reader.CurrentTime.TotalSeconds < 172)//dos veces
                lbl1.Text = "It'll be alright I want you to know that";
            if (reader.CurrentTime.TotalSeconds >= 172 && reader.CurrentTime.TotalSeconds < 175)//dos veces
                lbl1.Text = "I'll always believe in the truth of your words";

            if (reader.CurrentTime.TotalSeconds >=175 && reader.CurrentTime.TotalSeconds < 179)
                lbl1.Text = "With open arms, he looks to the sky";
            if (reader.CurrentTime.TotalSeconds >=179 && reader.CurrentTime.TotalSeconds < 183)
                lbl1.Text = "Finally, I've found my way";
            if (reader.CurrentTime.TotalSeconds >=183 && reader.CurrentTime.TotalSeconds <= 187)
                lbl1.Text = "My way to you";
            if (reader.CurrentTime.TotalSeconds > 187 && reader.CurrentTime.TotalSeconds < 189)
                lbl1.Text = " ";
            if (reader.CurrentTime.TotalSeconds >=189  && reader.CurrentTime.TotalSeconds <= 194)
                lbl1.Text = "My way to you";

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
