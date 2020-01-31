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
using RegistroIncripciones.Entidades;
using RegistroIncripciones.BLL;
using System.Linq;

namespace RegistroIncripciones.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cPersonas.xaml
    /// </summary>
    public partial class cPersonas : Window
    {
        public cPersonas()
        {
            InitializeComponent();
        }

        private void consultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Personas>();

            if (criterioTextBox.Text.Trim().Length > 0)
            {
                switch (filtroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = PersonasBLL.GetList(p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(criterioTextBox.Text);
                        listado = PersonasBLL.GetList(p => p.PersonaId == id);
                        break;

                    case 2:
                        listado = PersonasBLL.GetList(p => p.Nombre.Contains(criterioTextBox.Text));
                        break;

                    case 3:
                        listado = PersonasBLL.GetList(p => p.Cedula.Contains(criterioTextBox.Text));
                        break;

                    case 4:
                        listado = PersonasBLL.GetList(p => p.Direccion.Contains(criterioTextBox.Text));
                        break;

                }

                listado = listado.Where(c => c.FechaNacimiento.Date >= desdeDatePicker.SelectedDate && c.FechaNacimiento.Date <= hastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                listado = PersonasBLL.GetList(p => true);
            }

            consultarDataGrid.ItemsSource = listado;
            consultarDataGrid.ItemsSource = null;
        }
    }
}
