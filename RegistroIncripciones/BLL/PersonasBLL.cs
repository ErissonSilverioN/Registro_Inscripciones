using System;
using System.Collections.Generic;
using System.Text;
using RegistroIncripciones.Entidades;
using RegistroIncripciones.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace RegistroIncripciones.BLL

{
    public class PersonasBLL
    {
        public static bool Guardar(Personas personas)
        {
            bool paso = false;
            Contexto db = new Contexto();


            try
            {
                if (db.personas.Add(personas) != null)
                    paso = db.SaveChanges() > 0;

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



        public static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto db = new Contexto();


            try
            {

                db.Entry(personas).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);

            }
            catch
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
                var eliminar = db.personas.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

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


        public static Personas Buscar(int id)
        {
            Personas personas = new Personas();
            Contexto db = new Contexto();

            try
            {
                db.personas.Find(id);
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                db.Dispose();
            }

            return personas;

        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> Personas)
        {
            List<Personas> Lista = new List<Personas>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.personas.Where(Personas).ToList();
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
