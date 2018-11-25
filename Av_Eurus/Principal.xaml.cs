using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Windows.Forms;
using System.Windows.Input;
using System.Drawing;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Av_Eurus
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        SpeechRecognitionEngine euReco = new SpeechRecognitionEngine();
        SpeechSynthesizer euVoz = new SpeechSynthesizer();
       
        public Principal()
        {
            InitializeComponent();
            iniciarReconocedor();
        }
        void iniciarReconocedor()
        {
            euReco.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("Eurus"))));
            euReco.RequestRecognizerUpdate();

            euReco.SpeechRecognized += miestrasReconoce;
            euReco.AudioLevelUpdated += EuReco_AudioLevelUpdated;

            euReco.SetInputToDefaultAudioDevice();
            euReco.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void miestrasReconoce(object sender, SpeechRecognizedEventArgs e)
        {
            txtReconoce.Text = e.Result.Text;
        }

        private void EuReco_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            pgbNivelVoz.Value = e.AudioLevel;
        }

        int mainWidth;
        int mainHeight;
        Screen pantallaPrincipal = Screen.PrimaryScreen;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainWidth = pantallaPrincipal.Bounds.Width;
            mainHeight = pantallaPrincipal.Bounds.Height;

            lblMensaje.Content = mainWidth + " " + mainHeight;
        }

        private void move_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void move_2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            this.Width = mainWidth;
            this.Height = mainHeight;
            
            

        }

        private void move_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            configuracion euConf = new configuracion();
            euConf.Show();
        }
    }
}
