using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleApiTemplate.Models;

namespace SimpleApiTemplate.Data;

public class DataContext : IdentityDbContext<User>
{
    public DbSet<ExampleEntity> Examples { get; set; }

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