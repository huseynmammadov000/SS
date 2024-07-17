using Microsoft.EntityFrameworkCore;
using StartupShopping.Domain.Entities;
using StartupShopping.Domain.Entities.Common;
using StartupShopping.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Contexts
{
    public class StartupShoppingDbContext : DbContext
    {
        public StartupShoppingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Radar> Radars { get; set; }
        public DbSet<Startup> Startups { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<RefreshTokenValidation> RefreshTokenValidations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Startup>()
               .HasOne(s => s.User)
               .WithOne(u => u.Startup)
               .HasForeignKey<Startup>(s => s.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<AppUser>()
    .HasIndex(u => u.UserName)
    .IsUnique();

            modelBuilder.Entity<AppUserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<AppUserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<AppUserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<AppUser>()
           .HasOne(u => u.RefreshToken)
           .WithOne(r => r.User)
           .HasForeignKey<RefreshToken>(r => r.UserId);

            modelBuilder.Entity<AppUser>()
           .HasOne(u => u.Session)
           .WithOne()
           .HasForeignKey<Session>(s => s.UserId);


            modelBuilder.Entity<AppUser>()
              .HasOne(u => u.RefreshTokenValidation) // Bir AppUser'ın bir RefreshTokenValidation'ı var
              .WithOne() // Bu ilişkide tersten navigasyon gerekmeyebilir (Opsiyonel, yoksa WithOne(r => r.AppUser))
              .HasForeignKey<RefreshTokenValidation>(r => r.UserId);

            //modelBuilder.Entity<RefreshTokenValidation>().HasNoKey();

            modelBuilder.Entity<Role>().HasData(
              new Role { Id = Guid.NewGuid(), Name = "Admin" },
              new Role { Id = Guid.NewGuid(), Name = "Entrepreneur" },
              new Role { Id = Guid.NewGuid(), Name = "Investor" }
          );

            base.OnModelCreating(modelBuilder);
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
               .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateTime = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
