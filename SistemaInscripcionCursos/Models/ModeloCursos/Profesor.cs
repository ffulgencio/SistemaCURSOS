
using System.Collections.Generic;


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