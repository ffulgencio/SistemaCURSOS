using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInscripcionCursos.Models.ModeloCursos
{
    public class InscripcionHD
    {
        public int ID { get; set; }
        public DateTime FechaIns { get; set; }
        public int EstudianteID { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}