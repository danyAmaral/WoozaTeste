using Microsoft.EntityFrameworkCore;
using Wooza.PlanosTelefonia.Dominio;

namespace Wooza.PlanosTelefonia.Infraestrutura
{
    public class Contexto : DbContext
    {
        public Contexto() : base()
        {
        }

        public Contexto(DbContextOptions<Contexto> options) : base(options) {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBPlanosTelefonia;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigDDDs(builder);
            ConfigOperadoras(builder);
            ConfigPlanosTelefonia(builder);
            SeedData(builder);
        }
        private static void ConfigDDDs(ModelBuilder builder)
        {
            builder.Entity<DDD>(entity =>
            {
                entity.HasKey(e => e.Id);

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

                entity.HasIndex(e => e.OperadoraId);
                entity.HasIndex(e => e.DDDId);

                entity.HasOne(d => d.DDD)
                   .WithMany(p => p.PlanosTelefonicos)
                   .HasForeignKey(d => d.DDDId)
                   .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(o => o.Operadora)
                    .WithMany(p => p.PlanosTelefonicos)
                    .HasForeignKey(o => o.OperadoraId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }

        private static void SeedData(ModelBuilder builder)
        {
            builder.Entity<DDD>().HasData(
                new DDD() {Id=1, Codigo = 27, Cidade = "Vitória" , Estado = "ES"},
                new DDD() {Id=2, Codigo = 27, Cidade = "Serra", Estado = "ES" },
                new DDD() {Id=3, Codigo = 27, Cidade = "Vila Velha", Estado = "ES" },
                new DDD() {Id=4, Codigo = 33, Cidade = "Mantena", Estado = "MG" },
                new DDD() {Id=5, Codigo = 33, Cidade = "Governador Valadares", Estado = "MG" },
                new DDD() {Id=6, Codigo = 33, Cidade = "Araçuaí", Estado = "MG" },
                new DDD() {Id=7, Codigo = 21, Cidade = "Rio de Janeiro", Estado = "RJ" },
                new DDD() {Id=8, Codigo = 32, Cidade = "Juíz de Fora", Estado = "MG" },
                new DDD() {Id=9, Codigo = 84, Cidade = "Natal", Estado = "RN" }, 
                new DDD() {Id=10, Codigo = 24, Cidade = "Volta Redonda", Estado = "RJ" }
            );

            builder.Entity<Operadora>().HasData(
             new Operadora() { Id = 1, Nome = "Vivo" },
             new Operadora() { Id = 2, Nome = "Oi" },
             new Operadora() { Id = 3, Nome = "Tim" },
             new Operadora() { Id = 4, Nome = "Claro" }
            );

            builder.Entity<PlanoTelefonia>().HasData(
               new PlanoTelefonia() { 
                    Id = 1,
                    OperadoraId = 1, 
                    DDDId = 1,
                    FranquiaInternet = "4GB",
                    TipoPlano = TipoPlano.Controle, 
                    Minutos=500, 
                    Valor= 39.90m,
                    Codigo= "Controle Vivo"
                    },
                  new PlanoTelefonia()
                  {
                      Id = 2,
                      OperadoraId = 1,
                      DDDId = 1,
                      FranquiaInternet = "10GB",
                      TipoPlano = TipoPlano.Pos,
                      Minutos = 1000,
                      Valor = 79.90m,
                      Codigo = "Pós Vivo"
                  },
                new PlanoTelefonia()
                {
                    Id = 3,
                    OperadoraId = 1,
                    DDDId = 1,
                    FranquiaInternet = "2GB",
                    TipoPlano = TipoPlano.Pre,
                    Minutos = 300,
                    Valor = 19.90m,
                    Codigo = "Pré Vivo"
                },
                new PlanoTelefonia()
                {
                    Id = 4,
                    OperadoraId = 1,
                    DDDId = 4,
                    FranquiaInternet = "2GB",
                    TipoPlano = TipoPlano.Pre,
                    Minutos = 300,
                    Valor = 21.90m,
                    Codigo = "Pré Vivo"
                },
                new PlanoTelefonia()
                {
                    Id = 5,
                    OperadoraId = 1,
                    DDDId = 4,
                    FranquiaInternet = "4GB",
                    TipoPlano = TipoPlano.Controle,
                    Minutos = 500,
                    Valor = 39.90m,
                    Codigo = "Controle Vivo"
                },
                new PlanoTelefonia()
                {
                    Id = 6,
                    OperadoraId = 2,
                    DDDId = 7,
                    FranquiaInternet = "4GB",
                    TipoPlano = TipoPlano.Controle,
                    Minutos = 500,
                    Valor = 39.90m,
                    Codigo = "Controle Oi"
                },
                new PlanoTelefonia()
                {
                    Id = 7,
                    OperadoraId = 2,
                    DDDId = 7,
                    FranquiaInternet = "10GB",
                    TipoPlano = TipoPlano.Pos,
                    Minutos = 1000,
                    Valor = 79.90m,
                    Codigo = "Pós Oi"
                },
            new PlanoTelefonia()
            {
                Id = 8,
                OperadoraId = 2,
                DDDId = 7,
                FranquiaInternet = "2GB",
                TipoPlano = TipoPlano.Pre,
                Minutos = 300,
                Valor = 30.00m,
                Codigo = "Pré Oi"
            },
            new PlanoTelefonia()
            {
                Id = 9,
                OperadoraId = 2,
                DDDId = 1,
                FranquiaInternet = "2GB",
                TipoPlano = TipoPlano.Pre,
                Minutos = 300,
                Valor = 22.90m,
                Codigo = "Pré Oi"
            },
            new PlanoTelefonia()
            {
                Id = 10,
                OperadoraId = 2,
                DDDId = 7,
                FranquiaInternet = "4GB",
                TipoPlano = TipoPlano.Controle,
                Minutos = 500,
                Valor = 39.90m,
                Codigo = "Controle Oi"
            },
            new PlanoTelefonia()
            {
                Id = 11,
                OperadoraId = 3,
                DDDId = 7,
                FranquiaInternet = "4GB",
                TipoPlano = TipoPlano.Controle,
                Minutos = 500,
                Valor = 39.90m,
                Codigo = "Controle TIM"
            },
                new PlanoTelefonia()
                {
                    Id = 12,
                    OperadoraId = 3,
                    DDDId = 1,
                    FranquiaInternet = "10GB",
                    TipoPlano = TipoPlano.Pos,
                    Minutos = 1000,
                    Valor = 79.90m,
                    Codigo = "Pós TIM"
                },
            new PlanoTelefonia()
            {
                Id = 13,
                OperadoraId = 3,
                DDDId = 1,
                FranquiaInternet = "2GB",
                TipoPlano = TipoPlano.Pre,
                Minutos = 300,
                Valor = 30.00m,
                Codigo = "Pré TIM"
            },
            new PlanoTelefonia()
            {
                Id = 14,
                OperadoraId = 3,
                DDDId = 4,
                FranquiaInternet = "2GB",
                TipoPlano = TipoPlano.Pre,
                Minutos = 300,
                Valor = 22.90m,
                Codigo = "Pré TIM"
            },
            new PlanoTelefonia()
            {
                Id = 15,
                OperadoraId = 3,
                DDDId = 4,
                FranquiaInternet = "4GB",
                TipoPlano = TipoPlano.Controle,
                Minutos = 500,
                Valor = 39.90m,
                Codigo = "Controle TIM"
            },
            new PlanoTelefonia()
            {
                Id = 16,
                OperadoraId = 4,
                DDDId = 7,
                FranquiaInternet = "4GB",
                TipoPlano = TipoPlano.Controle,
                Minutos = 500,
                Valor = 39.90m,
                Codigo = "Controle Claro"
            },
            new PlanoTelefonia()
            {
                Id = 17,
                OperadoraId = 4,
                DDDId = 1,
                FranquiaInternet = "10GB",
                TipoPlano = TipoPlano.Pos,
                Minutos = 1000,
                Valor = 79.90m,
                Codigo = "Pós Claro"
            },
            new PlanoTelefonia()
            {
                Id = 18,
                OperadoraId = 4,
                DDDId = 1,
                FranquiaInternet = "2GB",
                TipoPlano = TipoPlano.Pre,
                Minutos = 300,
                Valor = 30.00m,
                Codigo = "Pré Claro"
            },
            new PlanoTelefonia()
            {
                Id = 19,
                OperadoraId = 3,
                DDDId = 7,
                FranquiaInternet = "2GB",
                TipoPlano = TipoPlano.Pre,
                Minutos = 300,
                Valor = 22.90m,
                Codigo = "Pré Claro"
            },
            new PlanoTelefonia()
            {
                Id = 20,
                OperadoraId = 3,
                DDDId = 7,
                FranquiaInternet = "4GB",
                TipoPlano = TipoPlano.Controle,
                Minutos = 500,
                Valor = 39.90m,
                Codigo = "Controle Claro"
            }
           );
        }

        public DbSet<DDD> DDDs { get; set; }
        public DbSet<Operadora> Operadoras { get; set; }
        public DbSet<PlanoTelefonia> PlanosTelefonia { get; set; }
    }
}
