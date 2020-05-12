using System;

namespace SaoDomingos.Dominio.Entities
{
    public class Diario
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Historico { get; set; }
        public decimal Valor { get; set; }
        public virtual PlanoContas Debito { get; set; }
        public string DebitoId { get; set; }
        public virtual PlanoContas Credito { get; set; }
        public string CreditoId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public virtual Participante Participante { get; set; }
        public int ParticipanteId { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
