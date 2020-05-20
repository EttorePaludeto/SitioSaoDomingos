using System;
using System.Collections.Generic;

namespace SaoDomingos.Web.Dev.Mvc.Models
{
    public partial class Diario
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string Historico { get; set; }
        public decimal? Valor { get; set; }
        public string DebitoId { get; set; }
        public string CreditoId { get; set; }
        public int? UsuarioId { get; set; }
        public int? ParticipanteId { get; set; }
        public DateTime? DataCadastro { get; set; }

        public  PlanoContas Credito { get; set; }
        public  PlanoContas Debito { get; set; }
        public  Participante Participante { get; set; }
        public  Usuario Usuario { get; set; }
    }
}
