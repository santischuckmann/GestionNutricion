using GestionNutricion.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionNutricion.Infrastructure.Data.Configurations
{
    public class MainCourseConfiguration : IEntityTypeConfiguration<MainCourse>
    {
        public void Configure(EntityTypeBuilder<MainCourse> builder)
        {
            builder.ToTable("MainCourse");

            builder.HasKey(m => m.MainCourseId);

            builder.Property(m => m.Food)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(m => m.Dessert)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(m => m.DietaryPlan)
                .WithMany(d => d.MainCourses)
                .HasForeignKey(s => s.DietaryPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(m => m.MainCourseType)
                .WithMany(d => d.MainCourses)
                .HasForeignKey(s => s.IdMainCourseType)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
