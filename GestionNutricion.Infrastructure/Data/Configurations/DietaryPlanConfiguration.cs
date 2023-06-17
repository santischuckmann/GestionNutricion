using GestionNutricion.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GestionNutricion.Infraestructure.Data.Configurations
{
    public class DietaryPlanConfiguration : IEntityTypeConfiguration<DietaryPlan>
    {
        public void Configure(EntityTypeBuilder<DietaryPlan> builder)
        {
            builder.ToTable("DietaryPlan");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Breakfast)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(d => d.Lunch)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(d => d.Dinner)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(d => d.Observations)
                .IsRequired();

        }
    }
}
