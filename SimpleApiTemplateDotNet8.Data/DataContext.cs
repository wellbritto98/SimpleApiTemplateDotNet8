using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleApiTemplateDotNet8.Models;
using SimpleApiTemplateDotNet8.Models.Auth;


namespace SimpleApiTemplateDotNet8.Data;

public class DataContext : IdentityDbContext<User>
{
    public DbSet<ExampleEntity> Examples { get; set; }

    public DbSet<Medication> Medications { get; set; }
    public DbSet<ModeloReceituario> ModeloReceituarios { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<IdentityUser>();

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "ADMIN".ToUpper() });
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        { Id = "2c5e174e-3b0e-446f-86af-483d56fd7211", Name = "Player", NormalizedName = "PLAYER".ToUpper() });

        //crie 4 medicações e 4 receitas
        for (int i = 1; i <= 4; i++)
        {
            var medication = new Medication
            {
                Id = i,
                Nome = $"Medication{i}",
                ViaAdministracao = $"Via Administracao {i}",
                DosegemMaxima = 10,
                IntervaloHoras = 2,
                DoseMinima = 1,
                DoseMaxima = 5,
                EmbalagemMl = 100
            };

            modelBuilder.Entity<Medication>().HasData(medication);

            var modeloReceituario = new ModeloReceituario
            {
                Id = i,
                NomeInstituicao = $"Nome Instituicao {i}",
                EnderecoInstituicao = $"Endereco Instituicao {i}",
                ImagemInstituicao = new byte[] { 0x20, 0x20, 0x20, 0x20 },
                NomePaciente = $"Nome Paciente {i}",
                NomeProfissional = $"Nome Profissional {i}",
                Data = DateTime.Now,
                Receita = $"Receita {i}"
            };

            modelBuilder.Entity<ModeloReceituario>().HasData(modeloReceituario);
        }


        for (int i = 1; i <= 12; i++)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(), // primary key
                UserName = $"user{i}",
                NormalizedUserName = $"USER{i}",
                Email = $"user{i}@example.com",
                NormalizedEmail = $"USER{i}@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password@123"),
                SecurityStamp = string.Empty,
                Nickname = $"User {i}",
                RegisteredAt = DateTime.Now,
                DataNascimento = new DateTime(1980, 1, 1),

            };

            modelBuilder.Entity<User>().HasData(user);


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                    UserId = user.Id
                }
            );

            var example = new ExampleEntity
            {
                Id = i,
                Name = $"Example{i}",
                Nickname = $"Example{i}Nickname",
                IsConfirmed = true
            };

            modelBuilder.Entity<ExampleEntity>().HasData(example);
        }
    }
}


/*

using SimpleApiTemplateDotNet8.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApiTemplateDotNet8.Models;

public class Medication : BaseEntity 
{
[Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public int Id { get; set; }

[Required]
public string Nome { get; set; }

[Required]
public string ViaAdministracao { get; set; }

[Required]
public decimal DosegemMaxima { get; set; }

[Required]
public int IntervaloHoras { get; set; }

[Required]
public decimal DoseMinima { get; set; }

[Required]
public decimal DoseMaxima { get; set; }

[Required]
public int EmbalagemMl { get; set; }
}

using SimpleApiTemplateDotNet8.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApiTemplateDotNet8.Models;

public class ModeloReceituario : BaseEntity 
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string NomeInstituicao { get; set; }
        public string EnderecoInstituicao { get; set; }
        public byte[] ImagemInstituicao { get; set; }
        public string NomePaciente { get; set; }
        public string NomeProfissional { get; set; }
        public DateTime Data { get; set; }
        public string Receita { get; set; }
}

*/