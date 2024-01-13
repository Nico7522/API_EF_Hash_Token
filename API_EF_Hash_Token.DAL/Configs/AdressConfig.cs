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
    internal class AdressConfig : IEntityTypeConfiguration<AdressEntity>
    {
        public void Configure(EntityTypeBuilder<AdressEntity> builder)
        {
            builder.HasKey(a => a.AdressId);
            builder.Property(a => a.AdressId).ValueGeneratedOnAdd();
            builder.Property(a => a.Number).IsRequired();
            builder.Property(a => a.CityName).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Street).HasMaxLength(350).IsRequired();
            builder.Property(a => a.Country).HasMaxLength(350).IsRequired();




        }
    }
}
