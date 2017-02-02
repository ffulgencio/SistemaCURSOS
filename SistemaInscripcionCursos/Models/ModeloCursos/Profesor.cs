using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInscripcionCursos.Models
{
    public class Profesor:Persona
    {

        public Profesor()
        {
            this.Cursos = null;
        }
        public List<Curso> Cursos { get; set; }
    }
}