using System;
using System.ComponentModel.DataAnnotations;

namespace SaoDomingos.Web.Dev.Mvc.Models
{
    public partial class Diario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        public DateTime? Data { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Historico { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal? Valor { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string DebitoId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CreditoId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? UsuarioId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")] 
        public int? ParticipanteId { get; set; }
        
        public DateTime? DataCadastro { get; set; }

        public  PlanoContas Credito { get; set; }
        public  PlanoContas Debito { get; set; }
        public  Participante Participante { get; set; }
        public  Usuario Usuario { get; set; }

       
    }
}
