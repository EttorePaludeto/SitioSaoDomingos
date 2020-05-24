using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaoDomingos.Web.Dev.Mvc.Models.ModelView
{
    public class DiarioView : Diario
    {
        public DiarioView(Diario d)
        {
            this.Id = d.Id;
            this.Data = d.Data;
            this.Historico = d.Historico;
            this.debitos = d.Debito.Contabil;
            this.creditos = d.Credito.Contabil;
            this.Valor = d.Valor;

        }

        public string debitos { get; set; }

        public string creditos { get; set; }
    }
    
}
