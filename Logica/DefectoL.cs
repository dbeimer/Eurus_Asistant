using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using Entidades;
using Logica.Properties;


namespace Logica
{
    public class DefectoL
    {
        static configuracionE eurusAsistant = new configuracionE();
        static Grammar defaultGramars, grmMultimedia, grmAfirmaNiega;
        public static void chargeGrammar(Grammar gramatica, SpeechRecognitionEngine reconocedor)
        {
            reconocedor.LoadGrammarAsync(gramatica);
        }
        public static configuracionE verificarConf()
        {
            if (Settings.Default.asistantName!=null&& Settings.Default.asistantName!="")
            {
                eurusAsistant.NombreAsistente = Settings.Default.asistantName;
            }
            else
            {
                eurusAsistant.NombreAsistente = "Eurus";
            }

            if (Settings.Default.userName != null && Settings.Default.userName != "")
            {
                eurusAsistant.NombreUsuario = Settings.Default.userName;
            }
            else
            {
                eurusAsistant.NombreUsuario = "señor";
            }

            if (Settings.Default.vozName != null && Settings.Default.vozName != "")
            {
                eurusAsistant.vozAsistente = Settings.Default.vozName;
            }

            return eurusAsistant;
           
        }
        public static void buildGramarMoreInteractive()
        {
         verificarConf();

        string[] aInicioGramatica = {eurusAsistant.NombreAsistente, "oye" };
        string[] aFinGramatica = { eurusAsistant.NombreAsistente, "por favor", "porfis" };

        GrammarBuilder gbdefaultGrammar = new GrammarBuilder();
            gbdefaultGrammar.Append(new Choices(aInicioGramatica), 0, 1);
            gbdefaultGrammar.Append(new SemanticResultKey("commadDefault", new Choices(defaultE.defaultGramar)));
            gbdefaultGrammar.Append(new Choices(aFinGramatica), 0, 1);
  

            GrammarBuilder gbMultiemdiaGrammar = new GrammarBuilder();
            gbdefaultGrammar.Append(new Choices(aInicioGramatica), 0, 1);
            gbMultiemdiaGrammar.Append(new SemanticResultKey("multimediaCommand", new Choices(defaultE.aMultimedia)));
            gbdefaultGrammar.Append(new Choices(aFinGramatica), 0, 1);

            GrammarBuilder gbAfNeg = new GrammarBuilder();
            gbdefaultGrammar.Append(new Choices(aInicioGramatica), 0, 1);
            gbAfNeg.Append(new SemanticResultKey("afirmacion", new Choices(defaultE.aAfirmaciones)), 0, 1);
            gbAfNeg.Append(new SemanticResultKey("negacion", new Choices(defaultE.aNegaciones)), 0, 1);
            gbdefaultGrammar.Append(new Choices(aFinGramatica), 0, 1);

            defaultGramars = new Grammar(gbdefaultGrammar);
            grmMultimedia = new Grammar(gbMultiemdiaGrammar);
            grmAfirmaNiega = new Grammar(gbAfNeg);
        }
        public static void chargeDefaultAsistantGrammars(SpeechRecognitionEngine reconocedor)
        {
            buildGramarMoreInteractive();
            chargeGrammar(defaultGramars, reconocedor);
            chargeGrammar(grmMultimedia, reconocedor);
            chargeGrammar(grmAfirmaNiega, reconocedor);
        }
    }
}
