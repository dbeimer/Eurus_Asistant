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
using Eurus_Asistant.Properties;
using Logica;
using Entidades;

namespace Eurus_Asistant
{
    /// <summary>
    /// Lógica de interacción para configuracion.xaml
    /// </summary>
    public partial class configuracion : Window
    {
        configuracionE eurus = DefectoL.verificarConf();
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
            lblCerrar.Opacity = 0;
            lblGuardar.Opacity = 0;
            lblMover.Opacity = 0;

            foreach (string voz in configuracionL.loadVoces())
            {
                cboVoces.Items.Add(voz);
            }
            txtNombreAsistente.Text = eurus.NombreAsistente;
            txtNombreUsuario.Text = eurus.NombreUsuario;
            cboVoces.Text = eurus.vozAsistente;
        }

        private void cboVoces_DropDownClosed(object sender, EventArgs e)
        {
            configuracionL.establecerVoice(cboVoces.Text);
        }

        private void move_Copy1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void move_Copy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            configuracionE euConf = new configuracionE();
            euConf.vozAsistente = cboVoces.Text;
            euConf.NombreAsistente = txtNombreAsistente.Text;
            euConf.NombreUsuario = txtNombreUsuario.Text;
            configuracionL.establecerConfiguracion(euConf);
        }

        private void move_Copy1_MouseMove(object sender, MouseEventArgs e)
        {
            lblCerrar.Opacity = 1;
        }

        private void move_Copy1_MouseLeave(object sender, MouseEventArgs e)
        {
            lblCerrar.Opacity = 0;
        }

        private void move_Copy_MouseMove(object sender, MouseEventArgs e)
        {
            lblGuardar.Opacity = 1;
        }

        private void move_Copy_MouseLeave(object sender, MouseEventArgs e)
        {
            lblGuardar.Opacity = 0;
        }

        private void move_MouseMove(object sender, MouseEventArgs e)
        {
            lblMover.Opacity = 1;
        }

        private void move_MouseLeave(object sender, MouseEventArgs e)
        {
            lblMover.Opacity = 0;
        }
    }
}
