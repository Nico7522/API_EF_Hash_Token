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
    public class CommandConfig : IEntityTypeConfiguration<CommandEntity>
    {
        public void Configure(EntityTypeBuilder<CommandEntity> builder)
        {
            builder.HasKey(c => c.OrderId);
            builder.Property(c => c.OrderId).ValueGeneratedOnAdd();
        }
    }
}
