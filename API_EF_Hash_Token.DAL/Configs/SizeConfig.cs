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
    public class SizeConfig : IEntityTypeConfiguration<SizeEntity>
    {
        public void Configure(EntityTypeBuilder<SizeEntity> builder)
        {
            builder.HasKey(s => s.SizeId);
            builder.Property(s => s.SizeId).ValueGeneratedOnAdd();
            builder.Property(s => s.Size).HasMaxLength(3).IsRequired();
            builder.Property(s => s.Stock).IsRequired();
        }
    }
}
