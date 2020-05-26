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
            this.participantes = d.Participante.Nome;
            this.debitos = d.Debito.Contabil;
            this.creditos = d.Credito.Contabil;
            this.Valor = d.Valor;
            this.DataCadastro = d.DataCadastro;
            this.usuarios = d.Usuario.Nome;
            this.DebitoId = d.DebitoId;
            this.CreditoId = d.CreditoId;
            this.ParticipanteId = d.ParticipanteId;
            this.UsuarioId = d.UsuarioId;

        }

        public string debitos { get; set; }
        public string creditos { get; set; }
        public string participantes { get; set; }
        public string usuarios { get; set; }
    }
    
}
