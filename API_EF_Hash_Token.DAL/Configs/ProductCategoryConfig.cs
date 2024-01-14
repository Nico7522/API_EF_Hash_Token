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
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });
            builder.HasOne(pc => pc.Product).WithMany(c => c.Categories).HasForeignKey(pc => pc.ProductId);
            builder.HasOne(pc => pc.Category).WithMany(c => c.Products).HasForeignKey(pc => pc.CategoryId);

        }
    }
}
