using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace MeuPensamento.DAO.Models
{
    public partial class MeuPensamentoContext : DbContext
    {
        public MeuPensamentoContext()
        {
        }

        public MeuPensamentoContext(DbContextOptions<MeuPensamentoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cartaoenfrentamento> Cartaoenfrentamentos { get; set; } = null!;
        public virtual DbSet<Pensamento> Pensamentos { get; set; } = null!;
        public virtual DbSet<Reacoes> Reacoes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(_configuration?.GetConnectionString("MeuPensamentoDbContext") ?? String.Empty);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartaoenfrentamento>(entity =>
            {
                entity.ToTable("CARTAOENFRENTAMENTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Mensagem)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("MENSAGEM");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Cartaoenfrentamentos)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CARTAOENF__IDUSU__2D27B809");
            });

            modelBuilder.Entity<Pensamento>(entity =>
            {
                entity.ToTable("PENSAMENTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Angustia).HasColumnName("ANGUSTIA");

                entity.Property(e => e.Ansiedade).HasColumnName("ANSIEDADE");

                entity.Property(e => e.Datahora)
                    .HasColumnType("datetime")
                    .HasColumnName("DATAHORA")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.MeuPensamento)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PENSAMENTO");

                entity.Property(e => e.Raiva).HasColumnName("RAIVA");

                entity.Property(e => e.Sentimento)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SENTIMENTO");

                entity.Property(e => e.Situacao)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SITUACAO");

                entity.Property(e => e.Tristeza).HasColumnName("TRISTEZA");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO").HasDefaultValue(true).HasConversion(I => I ? "S" : "N", S => S == "S");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Pensamentos)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PENSAMENT__IDUSU__267ABA7A");
            });

            modelBuilder.Entity<Reacoes>(entity =>
            {
                entity.ToTable("REACOES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idpensamento).HasColumnName("IDPENSAMENTO");

                entity.Property(e => e.Reacao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REACAO");

                entity.HasOne(d => d.IdpensamentoNavigation)
                    .WithMany(p => p.Reacoes)
                    .HasForeignKey(d => d.Idpensamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REACOES__IDPENSA__2A4B4B5E");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Senha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SENHA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
