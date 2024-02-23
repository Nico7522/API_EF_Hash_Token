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
        //private string _connectionString = "Data Source=DESKTOP-IFNFMI9;Initial Catalog=EF_LABO_SHOES;Integrated Security=True;Connect Timeout=60;";
        //private string _connectionString = "Data Source=GOS-VDI202\\TFTIC;Initial Catalog=EF_Hash_Token;Integrated Security=True;Connect Timeout=60;";

        public DbSet<UserEntity> Users { get { return Set<UserEntity>(); } }
        public DbSet<AdressEntity> Adresses { get { return Set<AdressEntity>(); } }
        public DbSet<UserAdressEntity> UserAdress { get { return Set<UserAdressEntity>(); } }
        public DbSet<ProductEntity> Products { get { return Set<ProductEntity>(); } }
        public DbSet<OrderEntity> Orders { get { return Set<OrderEntity>(); } }
        public DbSet<CategoryEntity> Categories { get { return Set<CategoryEntity>(); } }
        public DbSet<ProductCategoryEntity> ProductCategory { get { return Set<ProductCategoryEntity>(); } }

        public DbSet<ProductOrderEntity> ProductOrder { get { return Set<ProductOrderEntity>(); } }
        public DbSet<SizeEntity> Sizes { get { return Set<SizeEntity>(); } }
        public DbSet<SizeProductEntity> SizeProduct { get { return Set<SizeProductEntity>(); } }
        public DataContext(DbContextOptions options) : base(options) { }

        //Pour les tests
        public DataContext()
        {
        }


        //Constructeur utilisé par défaut
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);

        //}
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
            modelBuilder.Entity<ProductEntity>()
                        .HasMany(e => e.CategoriesEntity)
                        .WithMany(e => e.ProductsEntity)
                        .UsingEntity<ProductCategoryEntity>();

            modelBuilder.Entity<UserEntity>()
                       .HasMany(e => e.AdressesList)
                       .WithMany(e => e.UsersList)
                       .UsingEntity<UserAdressEntity>();

            modelBuilder.Entity<AdressEntity>()
                       .HasMany(e => e.UsersList)
                       .WithMany(e => e.AdressesList)
                       .UsingEntity<UserAdressEntity>();
        }
 
    }

}

