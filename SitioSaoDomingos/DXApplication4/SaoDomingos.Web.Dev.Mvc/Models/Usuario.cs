using System;
using System.Collections.Generic;

namespace SaoDomingos.Web.Dev.Mvc.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Diario = new HashSet<Diario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Diario> Diario { get; set; }
    }
}
