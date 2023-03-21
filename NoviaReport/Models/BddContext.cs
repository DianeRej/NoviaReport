using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace NoviaReport.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ProfessionalInfo> ProfessionalInfos { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=noviaReport");
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
            
            this.Users.AddRange(
                new User { Id = 1, Login = "DianeR", Password = Dal.EncodeMD5("ddddd"), ProfileId = 1 },
                new User { Id = 2, Login = "ShainA", Password = Dal.EncodeMD5("sssss"), ProfileId = 2 },
                new User { Id = 3, Login = "MoncefS", Password = Dal.EncodeMD5("mmmmm"), ProfileId = 3},
                new User { Id = 4, Login = "WafaA", Password = Dal.EncodeMD5("wwwww"), ProfileId = 4 }
                );

            this.SaveChanges();


        }
    }
}
