using Hospital.API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
namespace Hospital.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {            
        }

        // criando as tabelas no banco de dados 
        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<Paciente> Pacientes { get; set;}
        public DbSet<Funcionario> Funcionarios { get; set;}
        public DbSet<Medico> Medicos { get; set;}
        public DbSet<Cargo> Cargos {get ; set;}
        public DbSet <Especialidade> Especialidades { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  criando a herança ()
            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Paciente>("Paciente")
                .HasValue<Funcionario>("Funcionario")
                .HasValue<Medico>("Medico");
            
            // Criando Relacionamento Funcionario e Cargo
            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Cargo)
                .WithMany()
                .HasForeignKey(f=> f.CargoId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Criando Relacionamento Medico e sua especialidade trazendo de muito para muitos
            modelBuilder.Entity<Medico>()
                .HasMany(m=> m.Especialidades)
                .WithMany(e=> e.Medicos)
                .UsingEntity(j=> j.ToTable("MedicoEspecialidades"));

            
            // Trazendo os campos obrigatorios
            modelBuilder.Entity<Usuario>()
                .Property(u=> u.Nome)
                .IsRequired();
            modelBuilder.Entity<Usuario>()
                .Property(u=> u.CPF)
                .IsRequired();
            modelBuilder.Entity<Usuario>()
                .Property(u=> u.Email)
                .IsRequired();
            
            // 🔹 Seed Cargos
            modelBuilder.Entity<Cargo>().HasData(
                new Cargo { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Nome = "Técnico TI" },
                new Cargo { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Nome = "Analista Junior" },
                new Cargo { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Nome = "Analista Pleno" },
                new Cargo { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Nome = "Analista Senior" },
                new Cargo { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Nome = "Médico" },
                new Cargo { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Nome = "Recepção" },
                new Cargo { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Nome = "RH" },
                new Cargo { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Nome = "Serviços Gerais" }
            );

            modelBuilder.Entity<Especialidade>().HasData(
                new Especialidade { Id = Guid.Parse("00000000-0000-0000-0000-000000000101"), Nome = "Clínica Geral" },
                new Especialidade { Id = Guid.Parse("00000000-0000-0000-0000-000000000102"), Nome = "Pediatria" },
                new Especialidade { Id = Guid.Parse("00000000-0000-0000-0000-000000000103"), Nome = "Ortopedia" },
                new Especialidade { Id = Guid.Parse("00000000-0000-0000-0000-000000000104"), Nome = "Urologia" },
                new Especialidade { Id = Guid.Parse("00000000-0000-0000-0000-000000000105"), Nome = "Ginecologia" }
            );
            modelBuilder.Entity<Funcionario>().HasData(
                new Funcionario
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000009999"),
                    Nome = "Administrador TI",
                    CPF = "00000000000",
                    Email = "admin@hospital.com",
                    SenhaHash = "123456",
                    Tipo = TipoUsuario.Funcionario,
                    Nivel = NivelPermissao.Senior,
                    CargoId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    PrimeiroAcesso = true,
                    CriadoEm = DateTime.UtcNow
                }
            );
        }
    }
}
