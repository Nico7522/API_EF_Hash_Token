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
    public class OrderConfig : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.OrderId).ValueGeneratedOnAdd();
            builder.Property(o => o.TotalPrice).HasPrecision(11, 2).IsRequired();
            builder.Property(o => o.TotalReduction).HasPrecision(3, 2).HasDefaultValue(0);
            builder.Property(o => o.OrderDate).IsRequired();



        }
    }
}
