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
    internal class UserAdressConfig : IEntityTypeConfiguration<UserAdressEntity>
    {
        public void Configure(EntityTypeBuilder<UserAdressEntity> builder)
        {
            builder.HasKey(ua => new { ua.AdressId, ua.UserId });
            builder.HasOne(ua => ua.Adress).WithMany(a => a.Users).HasForeignKey(ua => ua.AdressId);
            builder.HasOne(ua => ua.User).WithMany(u => u.Addresses).HasForeignKey(ua => ua.UserId);

        }
    }
}
