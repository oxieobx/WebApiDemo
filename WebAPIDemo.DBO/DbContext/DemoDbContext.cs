using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIDemo.DBO.Entities;
using WebAPIDemo.DBO.EntitiesConfiguration;
using WebAPIDemo.DBO.Extensions;

namespace WebAPIDemo.DBO.DbContext
{
    public class DemoDbContext : IdentityDbContext<AppRole, AppUser, Guid>
    {
        public DemoDbContext()
        {

        }
        public DemoDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        //Cau hinh connectionString here nhung hien tai se cho vao file json
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-OEVHHDV\\SQLEXPRESS;Initial Catalog=WebAPIDemo;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }


        //Cau hinh fulent API here , seed data herre
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new AppRoleConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());

            //Config table name cho 1 so bang trong identities
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);


            builder.Seed();

            base.OnModelCreating(builder);

        }
    }
}
