using GestionNutricion.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionNutricion.Infrastructure.Data.Configurations
{
    public class PlanSnackConfiguration : IEntityTypeConfiguration<PlanSnack>
    {
        public void Configure(EntityTypeBuilder<PlanSnack> builder)
        {
            builder.ToTable("PlanSnack");

            builder.HasKey(p => p.PlanSnackId);

            builder.Property(p => p.Food)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(p => p.DietaryPlan)
                .WithMany(d => d.PlanSnacks)
                .HasForeignKey(s => s.DietaryPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(s => s.SnackTime)
                .WithMany(s => s.PlanSnacks)
                .HasForeignKey(s => s.IdSnackTime)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(false);
        }
    }
}
