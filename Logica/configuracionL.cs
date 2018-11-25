using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;

using Entidades;
using System.Data;

namespace Logica
{
    public class configuracionL
    {
        SpeechRecognitionEngine recoEu = new SpeechRecognitionEngine();
        SpeechSynthesizer vozEu = new SpeechSynthesizer();
        void inicializarVoz(configuracion confEu)
        {
            vozEu.SelectVoice(confEu.Voz);
          


        }

        public List<InstalledVoice> listarVoces()
        {
           

        }
    }
}
