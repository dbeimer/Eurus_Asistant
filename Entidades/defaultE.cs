using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class defaultE
    {
        public static string[] aMultimedia = { "pausa", "deten la musica", "reproducir", "play", "siguiente", "siguiente pista", "anterior", "pista anterior", "sube el volumen", "baja el volumen"
                                                , "stop","detente","OK","suficiente","ahí esta bien"};
        public static string[] defaultGramar = { "hola", "Hola eurus", "activa el mouse", "inicia el proyecto de pruebas",
                                                    "copiar","copia la selección","copia","copia esto","copialo",
                                                    "muestrame el escritorio", "minimiza todo",
                                                    "pegar","pega","pega aquí",
                                                    "haz una selección completa","seleciona todo","selección completa",
                                                    "elimina esto", "elimina","elimina la selección","borra esto","borrar",
                                                    "corta esto","corta la selección","cortar",
                                                    "crea una nueva carpeta","nueva carpeta",
                                                    "vacia la papelera", "limpia la papelera de reciclaje"};

        public static string[] aAfirmaciones = { "SI", "OK", "afirmativo", "claro" };
        public static string[] aNegaciones = { "NO", "negativo" };

        public static string[] aInicioGramatica = { configuracion.nombreAsistente == "" ? "Eurus" : configuracion.nombreAsistente, "oye" };
        public static string[] aFinGramatica = { configuracion.nombreAsistente == "" ? "Eurus" : configuracion.nombreAsistente, "por favor", "porfis" };
    }
}
