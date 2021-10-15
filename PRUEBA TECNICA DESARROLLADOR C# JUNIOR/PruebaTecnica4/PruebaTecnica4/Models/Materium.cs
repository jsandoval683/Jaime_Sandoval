using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica4.Models
{
    public partial class Materium
    {
        public Materium()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
