using GestionNutricion.Core.Entitys;
using GestionNutricion.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionNutricion.Infraestructure.Data.Configurations
{
    public class MainCourseTypeConfiguration : IEntityTypeConfiguration<MainCourseType>
    {
        public void Configure(EntityTypeBuilder<MainCourseType> builder)
        {
            MasterTableConfiguration.ApplyConfiguration("MainCourseType", builder);

            builder.HasKey(s => s.MainCourseTypeId);
        }
    }
}
