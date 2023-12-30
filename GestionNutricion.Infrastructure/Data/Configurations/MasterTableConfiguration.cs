using GestionNutricion.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.Data.Configurations
{
    internal class MasterTableConfiguration
    {
        public static void ApplyConfiguration<T>(string tableName, EntityTypeBuilder<T> builder) where T: MasterTableEntity
        {
            builder.ToTable(tableName);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

        }
    }
}
