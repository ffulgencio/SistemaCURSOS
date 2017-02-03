using SistemaInscripcionCursos.Models.ModeloCursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInscripcionCursos.Models
{
    public class InscripcionDT
    {
        public int Id { get; set; }
        public int InscripcionId { get; set; }
        public InscripcionHD InscripcionHD { get; set; }
        public int CursoID { get; set; }
        public virtual Curso Curso { get; set; }


    }
}