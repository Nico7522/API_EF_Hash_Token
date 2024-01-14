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
    public class ProductOrderConfig : IEntityTypeConfiguration<ProductOrderEntity>
    {
        public void Configure(EntityTypeBuilder<ProductOrderEntity> builder)
        {
            builder.HasKey(po => new { po.ProductId, po.OrderId });
            builder.HasOne(po => po.Product).WithMany(o => o.Orders).HasForeignKey(po => po.ProductId);
            builder.HasOne(po => po.Order).WithMany(o => o.Products).HasForeignKey(po => po.OrderId);
            builder.Property(po => po.Quantity).IsRequired();
            builder.Property(po => po.Price).HasPrecision(11, 2).IsRequired();
            builder.Property(po => po.ReductionPerProduct).HasPrecision(3, 2).HasDefaultValue(0);




        }
    }
}
