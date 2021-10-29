using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Notum
    {
        public int Id { get; set; }
        public double Nota { get; set; }
        public int IdAsignatura { get; set; }
        public int IdEstudiante { get; set; }
        public int IdPeriodo { get; set; }

        public virtual Asignatura IdAsignaturaNavigation { get; set; }
        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Periodo IdPeriodoNavigation { get; set; }
    }
}
