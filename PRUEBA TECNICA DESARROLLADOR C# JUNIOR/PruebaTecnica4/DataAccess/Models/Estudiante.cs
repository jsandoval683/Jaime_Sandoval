using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Nota = new HashSet<Notum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Notum> Nota { get; set; }
    }
}
