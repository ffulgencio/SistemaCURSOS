using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInscripcionCursos.Models.ModeloCursos
{
    public class Estudiante:Persona
    {
        public Estudiante()
        {
            this.Cursos = null;
        }
        public List<Curso> Cursos { get; set; }
    }
}