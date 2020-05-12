using SaoDomingos.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SaoDomingos.Dados.EF.Maps
{
    public class PlanoContasMap : EntityTypeConfiguration<PlanoContas>
    {
        public PlanoContasMap()
        {
            //Tabela
            ToTable(nameof(PlanoContas));
            //Chave Primária
            HasKey(x => x.Id);
            //Colunas
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Grupo).HasColumnName("Grupo");
            Property(x => x.SubGrupo).HasColumnName("SubGrupo");
            Property(x => x.Financeiro).HasColumnName("Financeiro");
            Property(x => x.Economico).HasColumnName("Economico");
            Property(x => x.Contabil).HasColumnName("Contabil");
            Property(x => x.DRE).HasColumnName("DRE");
            Property(x => x.DFC).HasColumnName("DFC");
            Property(x => x.Ativo).HasColumnName("Ativo");
        }
    }
}
