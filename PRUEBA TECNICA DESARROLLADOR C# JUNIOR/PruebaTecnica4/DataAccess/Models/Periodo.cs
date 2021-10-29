using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Periodo
    {
        public Periodo()
        {
            Nota = new HashSet<Notum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public virtual ICollection<Notum> Nota { get; set; }
    }
}
