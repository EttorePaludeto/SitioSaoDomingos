using System;
using System.Collections.Generic;

namespace SaoDomingos.Wep.Models
{
    public partial class Participante
    {
        public Participante()
        {
            Diario = new HashSet<Diario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Diario> Diario { get; set; }
    }
}
