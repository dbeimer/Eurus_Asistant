using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Data;
using Entidades;



namespace Logica
{
    public  class configuracionL
    {
        public static SpeechSynthesizer euVoz=new SpeechSynthesizer();
        public static SpeechSynthesizer euVozConfigurada()
        {
            if (configuracionE.voz!=null)
            {
                euVoz.SelectVoice(configuracionE.voz);
            }
            return euVoz;
        }
        public static List<string> loadVoces()
        {
            List<string> vocesLista = new List<string>();
            foreach (InstalledVoice voces in euVoz.GetInstalledVoices())
            {
                vocesLista.Add(voces.VoiceInfo.Name);
            }
            // vocesLista.Remove("Microsoft Mike");
            return vocesLista;
        }
    }
}
