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
    public class CategoryConfig : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(c => c.CategoryId);
            //builder.HasMany(p => p.ProductsEntity).WithMany(p => p.CategoriesEntity).UsingEntity<ProductCategoryEntity>(l => l.HasOne<ProductEntity>(c => c.Product).WithMany(c => c.Categories),
            //                                                                                                            r => r.HasOne<CategoryEntity>(p => p.Category).WithMany(p => p.Products));
            builder.Property(c => c.CategoryId).ValueGeneratedOnAdd();
            builder.Property(c => c.CategoryName).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(500).IsRequired();
        }
    }
}
