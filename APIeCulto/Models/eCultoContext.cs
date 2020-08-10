using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIeCulto.Models
{
    public partial class eCultoContext : DbContext
    {
        public eCultoContext()
        {
        }

        public eCultoContext(DbContextOptions<eCultoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Culto> Culto { get; set; }
        public virtual DbSet<Igreja> Igreja { get; set; }
        public virtual DbSet<Participacao> Participacao { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Culto>(entity =>
            {
                entity.HasKey(e => e.IdCulto)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdIgreja)
                    .HasName("FK_Culto_Igreja");

                entity.Property(e => e.IdCulto).HasColumnType("int(11)");

                entity.Property(e => e.DataHora).HasColumnType("datetime");

                entity.Property(e => e.IdIgreja).HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Preletor)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdIgrejaNavigation)
                    .WithMany(p => p.Culto)
                    .HasForeignKey(d => d.IdIgreja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Culto_Igreja");
            });

            modelBuilder.Entity<Igreja>(entity =>
            {
                entity.HasKey(e => e.IdIgreja)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdIgreja).HasColumnType("int(11)");

                entity.Property(e => e.Ativo).HasColumnType("int(11)");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Responsavel)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Tradicao)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnType("varchar(2)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Participacao>(entity =>
            {
                entity.HasKey(e => e.IdParticipacao)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCulto)
                    .HasName("FK_Participacao_Culto");

                entity.Property(e => e.IdParticipacao).HasColumnType("int(11)");

                entity.Property(e => e.ChaveApp)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdCulto).HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdCultoNavigation)
                    .WithMany(p => p.Participacao)
                    .HasForeignKey(d => d.IdCulto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participacao_Culto");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdTipoUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdIgreja)
                    .HasName("FK_Usuario_Igreja");

                entity.HasIndex(e => e.IdTipoUsuario)
                    .HasName("FK_Usuario_TipoUsuario");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Ativo).HasColumnType("tinyint(4)");

                entity.Property(e => e.IdIgreja).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdIgrejaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdIgreja)
                    .HasConstraintName("FK_Usuario_Igreja");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_TipoUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
