using SaoDomingos.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SaoDomingos.Dados.EF.Maps
{
    public class DiarioMap: EntityTypeConfiguration<Diario>
    {
        public DiarioMap()
        {
            //Tabela
            ToTable(nameof(Diario));
            //Chave Primária
            HasKey(x => x.Id);
            //Colunas
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Data).HasColumnName("Data");
            Property(x => x.Historico).HasColumnName("Historico");
            Property(x => x.Valor).HasColumnName("Valor");
            Property(x => x.DebitoId).HasColumnName("DebitoId");
            Property(x => x.CreditoId).HasColumnName("CreditoId");
            Property(x => x.UsuarioId).HasColumnName("UsuarioId");
            Property(x => x.ParticipanteId).HasColumnName("ParticipanteId");
            Property(x => x.DataCadastro).HasColumnName("DataCadastro");
            HasRequired(x => x.Debito)
                .WithMany()
                .HasForeignKey(x => x.DebitoId);
            HasRequired(x => x.Credito)
                .WithMany()
                .HasForeignKey(x => x.CreditoId);
            HasRequired(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);
            HasRequired(x => x.Participante)
                .WithMany()
                .HasForeignKey(x => x.ParticipanteId);


        }
    }
}
