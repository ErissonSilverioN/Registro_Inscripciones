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
using RegistroIncripciones.Entidades;
using RegistroIncripciones.DAL;

namespace RegistroIncripciones.UI.Registros
{
    /// <summary>
    /// Interaction logic for rInscripciones.xaml
    /// </summary>
    public partial class rInscripciones : Window
    {
        public rInscripciones()
        {
            InitializeComponent();
            idTextBox.Text = "0";
            montoTextBox.Text = "0";
           // personaidTextBox.Text = "0";
            LlenaCombo();
        }

        private void LlenaCombo()
        {
            PersonaComboBox.ItemsSource = PersonasBLL.GetList(c=> true);
            PersonaComboBox.DisplayMemberPath = "Nombre";
            PersonaComboBox.SelectedValuePath = "PersonaId";
        }


        private void Limpiar()
        {

            montoTextBox.Text = string.Empty;
            comentarioTextBox.Text = string.Empty;
            fechaDatePicker.SelectedDate = DateTime.Now;
            idTextBox.Text = "0";
          //  personaidTextBox.Text = "0";
           // balanceTextBox.Text = string.Empty;

        }

        private Inscripciones LlenaClase()
        {
            Inscripciones inscripciones = new Inscripciones();

            inscripciones.InscripcionId = Convert.ToInt32(idTextBox.Text);
            // inscripciones.PersonaId = Convert.ToInt32(personaidTextBox.Text);
            inscripciones.PersonaId = Convert.ToInt32(PersonaComboBox.SelectedValue);
            inscripciones.Monto = Convert.ToDecimal(montoTextBox.Text);
            inscripciones.Comentario = comentarioTextBox.Text;
            inscripciones.Fecha = fechaDatePicker.DisplayDate;
           // inscripciones.Balance = Convert.ToDecimal(balanceTextBox.Text);

            return inscripciones;

        }


        private void LlenaCampo(Inscripciones inscripciones)
        {
            idTextBox.Text = Convert.ToString(inscripciones.InscripcionId);
            // personaidTextBox.Text = Convert.ToString(inscripciones.PersonaId);
            PersonaComboBox.SelectedValue = inscripciones.PersonaId;

            montoTextBox.Text = Convert.ToString(inscripciones.Monto);
            comentarioTextBox.Text = inscripciones.Comentario;
            fechaDatePicker.SelectedDate = inscripciones.Fecha;
            

        }

        private bool ExisteEnLaBaseDato()
        {
           Inscripciones inscripciones = InscripcionesBLL.Buscar((int)Convert.ToInt32(idTextBox.Text));
            return (inscripciones != null);

        }


        private bool Validar()
        {
            bool paso = true;

            if (montoTextBox.Text == " ")
            {
                MessageBox.Show(" Llenar Campo!!");
                paso = false;
            }

            if (comentarioTextBox.Text == " ")
            {
                MessageBox.Show("Llenar Campo!!");
                paso = false;
            }

            return paso;

        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            Inscripciones inscripciones;
            bool paso = false;

            if (!Validar())
                return;

            inscripciones = LlenaClase();

            if (idTextBox.Text == "0")
                paso = InscripcionesBLL.Guardar(inscripciones);

            else
            {
                if (!ExisteEnLaBaseDato())
                {
                    MessageBox.Show("Inscripcion No Existe!!!");
                        return;
                }

                paso = InscripcionesBLL.Modificar(inscripciones);
            }

            if (paso)
            {
                MessageBox.Show("Se ha Guardado!!");
            }
            else
            {
                MessageBox.Show("No se ha Guardado!!");
            }
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            Contexto db = new Contexto();
            try
            {

                if (Convert.ToInt32(idTextBox.Text) > 0)
                {
                    Inscripciones inscripciones = new Inscripciones();
                    if ((inscripciones = db.inscripciones.Find((int)Convert.ToInt32(idTextBox.Text))) != null)
                    {
                        Limpiar();
                        LlenaCampo(inscripciones);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo buscar");
            }

        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(idTextBox.Text, out id);

            if (InscripcionesBLL.Eliminar(id))
            {
                MessageBox.Show("Se ha Eliminado!!");

            }
            else
            {
                MessageBox.Show("No se ha Eliminado!!");
            }
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

       


    }
}
