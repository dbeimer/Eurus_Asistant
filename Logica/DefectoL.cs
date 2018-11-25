using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using Entidades;


namespace Logica
{
    public class DefectoL
    {
        static Grammar defaultGramars, grmMultimedia, grmAfirmaNiega;
        public static void chargeGrammar(Grammar gramatica, SpeechRecognitionEngine reconocedor)
        {
            reconocedor.LoadGrammarAsync(gramatica);
        }
        public static void buildGramarMoreInteractive()
        {
            GrammarBuilder gbdefaultGrammar = new GrammarBuilder();
            gbdefaultGrammar.Append(new Choices("Eurus", "oye"), 0, 1);
            gbdefaultGrammar.Append(new SemanticResultKey("commadDefault", new Choices(defaultE.defaultGramar)));
            gbdefaultGrammar.Append(new Choices("Eurus"), 0, 1);
            gbdefaultGrammar.Append(new Choices("por favor"), 0, 1);

            GrammarBuilder gbMultiemdiaGrammar = new GrammarBuilder();
            gbMultiemdiaGrammar.Append(new Choices("Eurus", "oye"), 0, 1);
            gbMultiemdiaGrammar.Append(new SemanticResultKey("multimediaCommand", new Choices(defaultE.aMultimedia)));
            gbMultiemdiaGrammar.Append(new Choices("Eurus"), 0, 1);
            gbMultiemdiaGrammar.Append(new Choices("por favor"), 0, 1);

            GrammarBuilder gbAfNeg = new GrammarBuilder();
            gbAfNeg.Append(new Choices("Eurus", "oye"), 0, 1);
            gbAfNeg.Append(new SemanticResultKey("afirmacion", new Choices(defaultE.aAfirmaciones)), 0, 1);
            gbAfNeg.Append(new SemanticResultKey("negacion", new Choices(defaultE.aNegaciones)), 0, 1);
            gbAfNeg.Append(new Choices("Eurus"), 0, 1);
            gbAfNeg.Append(new Choices("por favor"), 0, 1);


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
