using SaoDomingos.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SaoDomingos.Dados.EF.Maps
{
    public class ParticipanteMap : EntityTypeConfiguration<Participante>
    {
        public ParticipanteMap()
        {
            //Tabela
            ToTable(nameof(Participante));
            //Chave Primária
            HasKey(x => x.Id);
            //Colunas
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Nome).HasColumnName("Nome");

        }
    }
}