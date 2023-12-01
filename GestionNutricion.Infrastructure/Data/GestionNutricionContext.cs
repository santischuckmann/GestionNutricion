using GestionNutricion.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;

namespace GestionNutricion.Infrastructure.Data
{
    public partial class GestionNutricionContext : DbContext
    {
        public GestionNutricionContext()
        {

        }

        public GestionNutricionContext(DbContextOptions<GestionNutricionContext> options) : base(options)
        {
        }
        
        public virtual DbSet<DietaryPlan> DietaryPlans { get; set; }
        public virtual DbSet<Snack> Snacks { get; set; }
        public virtual DbSet<PlanSnack> PlanSnacks { get; set; }
        public virtual DbSet<SnackTime> SnackTimes { get; set; }
        public virtual DbSet<MainCourse> MainCourses { get; set; }
        public virtual DbSet<MainCourseType> MainCourseType { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<User>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=GestionNutricion;User Id=santiago-root;Password=Santi2002,;Trust Server Certificate=true;");
        }
    }
}
