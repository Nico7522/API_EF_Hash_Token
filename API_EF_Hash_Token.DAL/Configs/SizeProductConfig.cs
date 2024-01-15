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
    public class SizeProductConfig : IEntityTypeConfiguration<SizeProductEntity>
    {
        public void Configure(EntityTypeBuilder<SizeProductEntity> builder)
        {
            builder.HasKey(sp => new { sp.SizeId, sp.ProductId });
            builder.HasOne(sp => sp.Size).WithMany(s => s.Products).HasForeignKey(sp => sp.SizeId);
            builder.HasOne(sp => sp.Product).WithMany(p => p.Sizes).HasForeignKey(sp => sp.ProductId);
            builder.Property(s => s.Stock).IsRequired();

        }
    }
}
