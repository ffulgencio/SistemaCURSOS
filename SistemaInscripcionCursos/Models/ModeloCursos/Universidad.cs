using SistemaInscripcionCursos.Models.ModeloCursos;
using System.Collections.Generic;

namespace SistemaInscripcionCursos.Models
{
    public class Universidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Estudiante> Estudiantes{ get; set; }
        public List<Profesor> Profesores { get; set; }
    }
}