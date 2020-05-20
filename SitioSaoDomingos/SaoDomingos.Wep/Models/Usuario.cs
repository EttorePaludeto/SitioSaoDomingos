using System;
using System.Collections.Generic;

namespace SaoDomingos.Wep.Models
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


        public virtual ICollection<Diario> Diario { get; set; }
    }
}
