using GestionNutricion.Core.Entitys;
using GestionNutricion.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GestionNutricion.Infraestructure.Data.Configurations
{
    public class SnackTimeConfiguration : IEntityTypeConfiguration<SnackTime>
    {
        public void Configure(EntityTypeBuilder<SnackTime> builder)
        {
            MasterTableConfiguration.ApplyConfiguration("SnackTime", builder);

            builder.HasKey(s => s.SnackTimeId);

        }
    }
}
