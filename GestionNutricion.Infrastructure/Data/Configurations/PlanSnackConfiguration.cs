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

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Food)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(p => p.IntakeHour)
                .IsRequired();

            builder.HasOne(p => p.DietaryPlan)
                .WithMany(d => d.PlanSnacks)
                .HasForeignKey(s => s.IdDietaryPlan)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
