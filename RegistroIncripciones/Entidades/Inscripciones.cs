using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroIncripciones.Entidades
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        public int PersonaId { get; set; }
        public string Comentario { get; set; }
        public decimal Monto { get; set; }
        
        public DateTime Fecha { get; set; }

     // [ForeignKey("PersonaId")]
     // public virtual Personas Personas { get; set; }    
             
    }
}
