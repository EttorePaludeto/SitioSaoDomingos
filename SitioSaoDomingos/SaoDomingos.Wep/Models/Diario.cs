using System;
using System.Collections.Generic;

namespace SaoDomingos.Wep.Models
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

        public virtual PlanoContas Credito { get; set; }
        public virtual PlanoContas Debito { get; set; }
        public virtual Participante Participante { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
