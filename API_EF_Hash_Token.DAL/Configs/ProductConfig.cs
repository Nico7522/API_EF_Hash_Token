using API_EF_Hash_Token.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.DAL.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.PrdoductId);
            //builder.HasMany(p => p.CategoriesEntity).WithMany(p => p.ProductsEntity).UsingEntity<ProductCategoryEntity>(l => l.HasOne<CategoryEntity>(c => c.Category).WithMany(c => c.Products),
            //                                                                                                            r => r.HasOne<ProductEntity>(p => p.Product).WithMany(p => p.Categories));
            builder.Property(p => p.PrdoductId).ValueGeneratedOnAdd();
            builder.Property(p => p.ModelName).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Brand).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Price).HasPrecision(11, 2).IsRequired();
            builder.Property(p => p.Discount).HasPrecision(3, 2).HasDefaultValue(0);
        }
    }
}
