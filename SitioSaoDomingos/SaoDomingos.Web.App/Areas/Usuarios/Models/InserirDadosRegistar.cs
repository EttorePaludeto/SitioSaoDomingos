using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaoDomingos.Web.App.Areas.Usuarios.Models
{
    public class InserirDadosRegistar
    {
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "SobreNome é obrigatório")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "Telefone incorreto")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato errado para Email")]
        public string Email { get; set; }

        [Display(Name ="Senha de Acesso")]
        [Required(ErrorMessage = "Senha é obrigatório")]
        [StringLength(8, ErrorMessage = "O numero máximo de caracteres é {0} e o mínimo {1}", MinimumLength = 6)]
        public string Senha { get; set; }
    }
}
