using Microsoft.EntityFrameworkCore;
using RegistroIncripciones.DAL;
using RegistroIncripciones.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace RegistroIncripciones.BLL
{
    public class InscripcionesBLL
    {

        public static bool Guardar(Inscripciones inscripciones)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                if (db.inscripciones.Add(inscripciones) != null)
                {
                    db.personas.Find(inscripciones.PersonaId).Balance += inscripciones.Monto;
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Inscripciones inscripciones)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {

                db.Entry(inscripciones).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;

        }


        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                var eliminar = db.inscripciones.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                db.personas.Find(eliminar.PersonaId).Balance -= eliminar.Monto;
                paso = (db.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;


        }


        public static Inscripciones Buscar(int id)
        {
            

            Contexto db = new Contexto();
            Inscripciones inscripciones = new Inscripciones();

            try
            {
                inscripciones = db.inscripciones.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return inscripciones ;


        }


        public static List<Inscripciones> GetList(Expression<Func<Inscripciones, bool>> inscripcion)
        {
            List<Inscripciones> Lista = new List<Inscripciones>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.inscripciones.Where(inscripcion).ToList();
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;

        }

       
    }
}
