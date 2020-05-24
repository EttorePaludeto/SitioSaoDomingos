using System;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace SaoDomingos.Web.Dev.Mvc.Models
{
    public partial class Base_SaoDomingosContext : DbContext
    {
        public Base_SaoDomingosContext()
        {
        }

        public Base_SaoDomingosContext(DbContextOptions<Base_SaoDomingosContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Diario> Diario { get; set; }
        public virtual DbSet<Participante> Participante { get; set; }
        public virtual DbSet<PlanoContas> PlanoContas { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Base_SaoDomingos;User ID=sa;Password=123456;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diario>(entity =>
            {
               
                entity.Property(e => e.CreditoId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.DataCadastro).HasColumnType("date");

                entity.Property(e => e.DebitoId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Historico)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Credito)
                    .WithMany(p => p.DiarioCredito)
                    .HasForeignKey(d => d.CreditoId)
                    .HasConstraintName("FK_Diario_PlanoContasCredito");

                entity.HasOne(d => d.Debito)
                    .WithMany(p => p.DiarioDebito)
                    .HasForeignKey(d => d.DebitoId)
                    .HasConstraintName("FK_Diario_PlanoContasDebito");

                entity.HasOne(d => d.Participante)
                    .WithMany(p => p.Diario)
                    .HasForeignKey(d => d.ParticipanteId)
                    .HasConstraintName("FK_Diario_Participante");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Diario)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Diario_Usuario");
            });

            modelBuilder.Entity<Participante>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlanoContas>(entity =>
            {
                entity.HasKey("Id");

                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Ativo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Contabil)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Dfc)
                    .HasColumnName("DFC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dre)
                    .HasColumnName("DRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Economico)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Financeiro)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SubGrupo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }
    }
}
