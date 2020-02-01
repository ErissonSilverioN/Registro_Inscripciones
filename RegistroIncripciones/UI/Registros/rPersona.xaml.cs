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
using RegistroIncripciones.UI.Registros;
using RegistroIncripciones.DAL;

namespace RegistroIncripciones.UI.Registros
{
    /// <summary>
    /// Interaction logic for rPersona.xaml
    /// </summary>
    public partial class rPersona : Window
    {
        public rPersona()
        {
            InitializeComponent();
            balanceTextBox.Text = "0";
            IdTextBox.Text = "0";
        }

        private void Limpiar()
        {

            nombreTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            cedulaTextBox.Text = string.Empty;
            direccionTextBox.Text = string.Empty;
            balanceTextBox.Text = string.Empty;
            fechanacimientoDatePicker.SelectedDate = DateTime.Now;
            IdTextBox.Text = "0";

        }


        private Personas LlenaClase()
        {
            Personas personas = new Personas();

            personas.PersonaId = Convert.ToInt32(IdTextBox.Text);
            personas.Nombre = nombreTextBox.Text;
            personas.Telefono = telefonoTextBox.Text;
            personas.Cedula = cedulaTextBox.Text;
            personas.Direccion = direccionTextBox.Text;
            personas.FechaNacimiento = fechanacimientoDatePicker.DisplayDate;
            personas.Balance = Convert.ToDecimal(balanceTextBox.Text);

            return personas;

        }

        private void LlenaCampo(Personas personas)
        {
            Inscripciones ins = new Inscripciones();

            decimal Montos;

            if (personas.PersonaId == ins.PersonaId)
            {
               // balanceTextBox.Text = Convert.ToString(ins.Monto);
                Montos =+ ins.Monto;
            }
            personas.PersonaId = ins.PersonaId;

            IdTextBox.Text = Convert.ToString(personas.PersonaId);
            nombreTextBox.Text = personas.Nombre;
            telefonoTextBox.Text = personas.Telefono;
            cedulaTextBox.Text = personas.Cedula;
            direccionTextBox.Text = personas.Direccion;
            balanceTextBox.Text = personas.Balance.ToString();

        }


        private bool ExisteEnLaBaseDatos()
        {
            Personas personas = PersonasBLL.Buscar((int)Convert.ToInt32(IdTextBox.Text));
            return (personas != null);
        }


        private bool Validar()
        {
            bool paso = true;

            if (nombreTextBox.Text == " ")
            {
                MessageBox.Show("Llenar Campo!!");
                paso = false;

            }

            if (telefonoTextBox.Text == " ")
            {
                MessageBox.Show("Llenar Campo!!");
                paso = false;
            }

            if (cedulaTextBox.Text == " ")
            {
                MessageBox.Show(" Llenar Campo");
                paso = false;


            }

            if (direccionTextBox.Text == " ")
            {
                MessageBox.Show(" Llenar Campo");
                paso = false;
            }

            return paso;
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas personas;
            bool paso = false;

            if (!Validar())
                return;

            personas = LlenaClase();

            if (IdTextBox.Text == "0")
                paso = PersonasBLL.Guardar(personas);

            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("La persona no existe");
                    return;
                }
                paso = PersonasBLL.Modificar(personas);
            }


            if (paso)
            {
                MessageBox.Show("Se ha Guardado!!");
                Limpiar();

            }
            else
            {
                MessageBox.Show("No se ah Guardado");
            }


        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {

            Contexto db = new Contexto();
            try
            {

                if (Convert.ToInt32(IdTextBox.Text) > 0)
                {
                    Personas personas = new Personas();
                    if ((personas = db.personas.Find((int)Convert.ToInt32(IdTextBox.Text))) != null)
                    {
                        Limpiar();
                        LlenaCampo(personas);
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
            int.TryParse(IdTextBox.Text, out id);

            if (PersonasBLL.Eliminar(id))
            {
                Limpiar();
                MessageBox.Show("Eliminado!!!");
                
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar!!!");
            }
           
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

    }
}

           
