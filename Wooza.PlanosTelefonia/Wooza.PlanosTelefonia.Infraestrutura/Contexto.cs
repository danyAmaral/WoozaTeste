using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wooza.PlanosTelefonia.Dominio;

namespace Wooza.PlanosTelefonia.Infraestrutura
{
    public class Contexto : DbContext
    {
        public Contexto() : base()
        {
        }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigDDDs(builder);

            ConfigOperadoras(builder);

            ConfigPlanosTelefonia(builder);
      
        }
        private static void ConfigDDDs(ModelBuilder builder)
        {
            builder.Entity<DDD>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Cidade).HasMaxLength(255).IsRequired();

                entity.Property(e => e.Estado).HasMaxLength(255).IsRequired();

            });
        }

        private static void ConfigOperadoras(ModelBuilder builder)
        {
            builder.Entity<Operadora>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(255).IsRequired();
            });
        }

        private static void ConfigPlanosTelefonia(ModelBuilder builder)
        {
            builder.Entity<PlanoTelefonia>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Codigo).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Minutos).IsRequired();
                entity.Property(e => e.FranquiaInternet).IsRequired();
                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");


                entity.HasOne(d => d.DDD)
                   .WithMany(p => p.PlanosTelefonicos)
                   .HasForeignKey(d => d.CodigoDDD)
                   .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(o => o.Operadora)
                    .WithMany(p => p.PlanosTelefonicos)
                    .HasForeignKey(o => o.OperadoraId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }

        private static void SeedData(ModelBuilder builder)
        {
            throw new NotImplementedException();
        }

        public DbSet<DDD> DDDs { get; set; }
        public DbSet<Operadora> Operadoras { get; set; }
        public DbSet<PlanoTelefonia> PlanosTelefonia { get; set; }
    }
}
