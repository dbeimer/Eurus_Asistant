using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class configuracionE
    {
        
            public static string voz;
            public static string nombreAsistente;
            public static string nombreUsuario;

            public static bool cambios = false;


        public string vozAsistente { get; set; }
        public string NombreAsistente
            {
                get
                {
                    return nombreAsistente;
                }

                set
                {
                    nombreAsistente = value;
                }
            }

            public string NombreUsuario
            {
                get
                {
                    return nombreUsuario;
                }

                set
                {
                    nombreUsuario = value;
                }
            }
        }
    
}
