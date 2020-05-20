using System;
using System.Collections.Generic;

namespace SaoDomingos.Web.Dev.Mvc.Models
{
    public partial class Participante
    {
        public Participante()
        {
            Diario = new HashSet<Diario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Diario> Diario { get; set; }
    }
}
