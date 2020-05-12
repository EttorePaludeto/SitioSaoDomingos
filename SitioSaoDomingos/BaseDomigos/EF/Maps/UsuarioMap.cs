using SaoDomingos.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SaoDomingos.Dados.EF.Maps
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //Tabela
            ToTable(nameof(Usuario));
            //Chave Primária
            HasKey(x => x.Id);
            //Colunas
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Nome).HasColumnName("Nome");
        }
    }
}