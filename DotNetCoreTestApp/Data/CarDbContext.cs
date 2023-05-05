using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreTestApp.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
        }
        public DbSet<CarForm> CarForms { get; set; }
        public DbSet<Addon> Addons { get; set; }
        public DbSet<Selection> Selections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Selection>()
                .HasKey(s => new { s.CarFormId, s.AddonId });

            modelBuilder.Entity<Addon>().HasData(
                new Addon { Id = 1, CheckboxName = "10%off First service visit" },
                new Addon { Id = 2, CheckboxName = "10%off Waterwash" },
                new Addon { Id = 3, CheckboxName = "Free AC Inspection" });
        }
    }

    public class CarForm
    {
        public int Id { get; set; }
        [Required]
        public string CarModel { get; set; }
        


    }
    public class Addon
    {
        public int Id { get; set; }
        public string? CheckboxName { get; set; }
        public bool IsChecked { get; set; }
    }

    public class CarFormViewModel
    {
        public int Id { get; set; }
        public string? CarModel { get; set; }
        public List<Addon>? Addons { get; set; }
    }
    public class Selection
    {
        public int CarFormId { get; set; }
        public CarForm CarForms { get; set; }

        public Addon Addons { get; set; }
        public int AddonId { get; set; }

    }
}
