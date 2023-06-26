using GestionNutricion.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                .HasMaxLength(50);

            builder.Property(d => d.Observations)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);

        }
    }
}
