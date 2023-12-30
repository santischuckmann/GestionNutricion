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

            builder.HasKey(d => d.DietaryPlanId);

            builder.Property(d => d.Breakfast)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Observations)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);

            builder.HasOne(m => m.Patient)
                .WithMany(d => d.DietaryPlans)
                .HasForeignKey(s => s.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
