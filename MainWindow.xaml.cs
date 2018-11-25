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

//para el habla y reconocimento
using System.Speech.Recognition;
using System.Speech.Synthesis;

//capas
using Logica;
using Entidades;

namespace Eurus_Asistant
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine euReco = new SpeechRecognitionEngine();
        SpeechSynthesizer euVoz = configuracionL.euVozConfigurada();
        string fraseReconocida;
        public MainWindow()
        {
            InitializeComponent();
            iniciarReconocedor();
        }
        void iniciarReconocedor()
        {
            euReco.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("Eurus"))));
            euReco.RequestRecognizerUpdate();
            DefectoL.chargeDefaultAsistantGrammars(euReco);

            euReco.SpeechRecognized += mientrasReconoce;
            euReco.AudioLevelUpdated += EuReco_AudioLevelUpdated;

            euReco.SetInputToDefaultAudioDevice();
            euReco.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void EuReco_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            //   throw new NotImplementedException();
            pgbNivelVoz.Value = e.AudioLevel;
        }

        private void mientrasReconoce(object sender, SpeechRecognizedEventArgs e)
        {
            //    throw new NotImplementedException();
            euVoz = configuracionL.euVozConfigurada();
            fraseReconocida = e.Result.Text;
            txtReconoce.Text = fraseReconocida;
            switch (fraseReconocida.ToLower())
            {
                case "hola eurus":
                    euVoz.SpeakAsync("hola señor");break;
                default:
                    break;
            }
        }

        private void move_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void conf_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            configuracion conf = new configuracion();
            conf.ShowDialog();
        }
    }
}
