using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaInscripcionCursos.Models
{
    public class Persona
    {
       
        public int Id{ get; set; }

        [MaxLength(75)]
        public String Nombre { get; set; }
        [MaxLength(75)]
        public String Apellido { get; set; }
        public char Sexo { get; set; }
        public int UniversidadID { get; set; }
        public Universidad Universidad { get; set; }
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }
        public String Email { get; set; }
        [MaxLength(13)]
        public String Telefono { get; set; }
        [MaxLength(13)]
        public String Celular { get; set; }


       
    }
}