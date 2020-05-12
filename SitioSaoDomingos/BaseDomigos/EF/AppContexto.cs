using SaoDomingos.Dados.EF.Maps;
using SaoDomingos.Dominio.Entities;
using System.Data.Entity;

namespace SaoDomingos.Dados.EF
{
    public class AppContexto : DbContext
    {

        public AppContexto() : base("name=ConnStringDomingos")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DiarioMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new ParticipanteMap());
            modelBuilder.Configurations.Add(new PlanoContasMap());
        }

        public virtual DbSet<Diario> Diarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Participante> Participantes { get; set; }
        public virtual DbSet<PlanoContas> PlanosContas { get; set; }

    }
}