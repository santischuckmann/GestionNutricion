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

            builder.HasKey(m => m.Id);

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
                .HasForeignKey(s => s.IdDietaryPlan)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
