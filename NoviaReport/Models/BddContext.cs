using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace NoviaReport.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ProfessionalInfo> ProfessionalInfos { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=projet2");
        }

        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            this.Profiles.AddRange(
                new Profile { Id = 1, Firstname = "Diane", Lastname = "Reja" },
                new Profile { Id = 2, Firstname = "Shain", Lastname = "Arbam" },
                new Profile { Id = 3, Firstname = "Moncef", Lastname = "Said" },
                new Profile { Id = 4, Firstname = "Wafa", Lastname = "Ayeb" }
                );


            this.SaveChanges();


        }
    }
}
