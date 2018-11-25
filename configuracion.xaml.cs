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
using System.Windows.Shapes;
using Logica;
using Entidades;

namespace Eurus_Asistant
{
    /// <summary>
    /// Lógica de interacción para configuracion.xaml
    /// </summary>
    public partial class configuracion : Window
    {
        public configuracion()
        {
            InitializeComponent();
        }

        private void move_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void config_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string voz in configuracionL.loadVoces())
            {
                cboVoces.Items.Add(voz);
            }
        }

        private void cboVoces_DropDownClosed(object sender, EventArgs e)
        {
            configuracionE.voz = cboVoces.Text;
        }
    }
}
