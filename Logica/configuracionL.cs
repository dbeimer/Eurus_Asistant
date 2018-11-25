using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Data;
using Entidades;
using Logica.Properties;




namespace Logica
{
    public  class configuracionL
    {
        public static SpeechSynthesizer euVoz=new SpeechSynthesizer();
        public static SpeechSynthesizer euVozConfigurada()
        {
            if (Settings.Default.vozName!=null&& Settings.Default.vozName!="")
            {
                euVoz.SelectVoice(Settings.Default.vozName);
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

        public static void establecerVoice(string voz)
        {
        }

        public static void establecerConfiguracion(configuracionE conf)
        {
            Settings.Default.userName = conf.NombreUsuario;
            Settings.Default.asistantName = conf.NombreAsistente;
            Settings.Default.vozName = conf.vozAsistente;
            Settings.Default.Save();
            configuracionE.cambios = true;
            
        }
    }
}
