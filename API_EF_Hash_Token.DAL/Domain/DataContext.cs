using API_EF_Hash_Token.DAL.Configs;
using API_EF_Hash_Token.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Domain
{
    public class DataContext : DbContext
    {
        private string _connectionString = "Data Source=GOS-VDI202\\TFTIC;Initial Catalog=EF_Hash_Token;Integrated Security=True;Connect Timeout=60;";

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdressEntity> Adresses { get; set; }
        public DbSet<UserAdressEntity> UserAdress { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductOrderEntity> ProductOrder { get; set; }
        public DbSet<SizeEntity> Sizes { get; set; }
        public DbSet<SizeProductEntity> SizeProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new AdressConfig());
            modelBuilder.ApplyConfiguration(new UserAdressConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new ProductOrderConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
            modelBuilder.ApplyConfiguration(new SizeConfig());
            modelBuilder.ApplyConfiguration(new SizeProductConfig());
        }
        public void ConfigureService(IServiceCollection service)
        {
            service.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer("server=.;database=myDb;trusted_connection=true;");
            });
        }
    }

}

