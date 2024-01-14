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
    public class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.UserId).ValueGeneratedOnAdd();
            builder.Property(u => u.FirstName).HasMaxLength(150).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(150).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(250).IsRequired();
            builder.Property(u => u.PhoneNumber).HasMaxLength(300).IsRequired();
            builder.Property(u => u.Role).HasDefaultValue("User");
            builder.Property(u => u.IsActive).HasDefaultValue(false);
            builder.HasMany(u => u.Orders).WithOne(o => o.User);
        }
    }
}
