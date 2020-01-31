using RegistroIncripciones.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroIncripciones.BLL;
using System.Linq;

namespace RegistroIncripciones.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cInscripciones.xaml
    /// </summary>
    public partial class cInscripciones : Window
    {
        public cInscripciones()
        {
            InitializeComponent();
        }

        private void consultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Inscripciones>();

            if (criterioTextBox.Text.Trim().Length > 0)
            {
                switch (filtroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = InscripcionesBLL.GetList(p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(criterioTextBox.Text);
                        listado = InscripcionesBLL.GetList(p => p.InscripcionId == id);
                        break;

                    case 2:
                        int monto = Convert.ToInt32(criterioTextBox.Text);
                        listado = InscripcionesBLL.GetList(p => p.Monto == monto);
                        break;

                }

                listado = listado.Where(c => c.Fecha.Date >= desdeDatePicker.SelectedDate.Value && c.Fecha.Date <= hastaDatePicker.SelectedDate.Value).ToList();

            }
            else
            {
                listado = InscripcionesBLL.GetList(p => true);
            }

            consultarDataGrid.ItemsSource = listado;
        }
    }
}
