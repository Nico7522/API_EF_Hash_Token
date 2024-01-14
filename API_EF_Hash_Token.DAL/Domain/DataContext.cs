using API_EF_Hash_Token.DAL.Configs;
using API_EF_Hash_Token.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Domain
{
    public class DataContext : DbContext
    {
        private string _connectionString = "Data Source=DESKTOP-IFNFMI9;Initial Catalog=EF_Hash_Token;Integrated Security=True;Connect Timeout=60;";

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdressEntity> Adresses { get; set; }
        public DbSet<UserAdressEntity> UserAdress { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }




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







        }
    }
}
