using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica4.Models
{
    public partial class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public double Periodo { get; set; }
        public double Nota { get; set; }
        public int IdMateria { get; set; }

        public virtual Materium IdMateriaNavigation { get; set; }
    }
}
