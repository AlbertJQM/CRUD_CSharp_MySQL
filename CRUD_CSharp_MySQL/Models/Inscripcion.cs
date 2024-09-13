using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_CSharp_MySQL.Models
{
    public class Inscripcion
    {
        public int InscripcionID { get; set; }
        public int EstudianteID { get; set; }
        public int CursoID { get; set; }
        public DateTime FechaInscripcion { get; set; }
    }
}
