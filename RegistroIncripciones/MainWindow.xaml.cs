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
using RegistroIncripciones.UI.Registros;
using RegistroIncripciones.UI.Consultas;

namespace RegistroIncripciones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void _RegistroPersona_Click(object sender, RoutedEventArgs e)
        {
            rPersona registro = new rPersona();
            registro.ShowDialog();
        }

        private void _RegistroInscripciones_Click(object sender, RoutedEventArgs e)
        {
            rInscripciones registro = new rInscripciones();
            registro.ShowDialog();

        }

       

        private void _ConsultaInscripciones_Click(object sender, RoutedEventArgs e)
        {
            cInscripciones consulta = new cInscripciones();
            consulta.ShowDialog();
            
        }

        private void _ConsultaPersonas_Click(object sender, RoutedEventArgs e)
        {
            cPersonas consulta = new cPersonas();
            consulta.ShowDialog();
        }
    }
}
