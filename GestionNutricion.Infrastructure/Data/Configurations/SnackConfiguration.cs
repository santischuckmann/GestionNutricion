﻿using GestionNutricion.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GestionNutricion.Infraestructure.Data.Configurations
{
    public class SnackConfiguration : IEntityTypeConfiguration<Snack>
    {
        public void Configure(EntityTypeBuilder<Snack> builder)
        {
            builder.ToTable("Snack");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Food)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(s => s.IntakeHour)
                .IsRequired();

        }
    }
}