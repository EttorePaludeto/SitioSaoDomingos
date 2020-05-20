using System;
using System.Collections.Generic;

namespace SaoDomingos.Wep.Models
{
    public partial class PlanoContas
    {
        public PlanoContas()
        {
            DiarioCredito = new HashSet<Diario>();
            DiarioDebito = new HashSet<Diario>();
        }

        public string Id { get; set; }
        public string Grupo { get; set; }
        public string SubGrupo { get; set; }
        public string Financeiro { get; set; }
        public string Economico { get; set; }
        public string Contabil { get; set; }
        public string Dre { get; set; }
        public string Dfc { get; set; }
        public string Ativo { get; set; }

        public virtual ICollection<Diario> DiarioCredito { get; set; }
        public virtual ICollection<Diario> DiarioDebito { get; set; }
    }
}
