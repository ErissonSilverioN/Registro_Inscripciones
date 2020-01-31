using Microsoft.EntityFrameworkCore;
using RegistroIncripciones.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroIncripciones.DAL
{
    public class Contexto : DbContext
    {
       public DbSet<Personas> personas { get; set; }
       public DbSet<Inscripciones> inscripciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =.\SqlExpress; DataBase =RegistroInscripcionesDB; Trusted_Connection = True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
 