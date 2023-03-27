using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NoviaReport.Models.DAL_IDAL;
using System;

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
        public DbSet<CRA> CRAs { get; set; }
        public DbSet<Activity> Activities{ get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
      //  public DbSet<TypeActivity> TypeActivities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=noviaReport");
        }

        //Méthode différente que "?" pour dire que la valeur de cette table peut être nulle
                /* protected override void OnModelCreating(ModelBuilder modelBuilder) {
                          modelBuilder.Entity<Activity>().Property(m => m.Absences).IsRequired(false);
                          base.OnModelCreating(modelBuilder); }*/

        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            this.Users.AddRange(
                new User { Id = 1, Login = "Dia0ne@projet2", Password = "123", ContactId = 1, ProfileId = 1, ProfessionalInfoId = 1 },
                new User { Id = 2, Login = "Shain@projet2", Password = "456", ContactId = 2, ProfileId = 2, ProfessionalInfoId = 2 },
                new User { Id = 3, Login = "Moncef@projet2", Password = "789", ContactId = 3, ProfileId = 3, ProfessionalInfoId = 3 });


            this.Profiles.AddRange(
                new Profile { Id = 1, Firstname = "Diane", Lastname = "Reja" },
                new Profile { Id = 2, Firstname = "Shain", Lastname = "Arbam" },
                new Profile { Id = 3, Firstname = "Moncef", Lastname = "Said" },
                new Profile { Id = 4, Firstname = "Wafa", Lastname = "Ayeb" }
                );
            
           

            this.Contacts.AddRange(
                new Contact { Id = 1, PersonalMail = "Diane@gmail.com", ProMail = "Diane@projet2", PersonalPhone = 061234566, ProPhone = 061234566,  AdressId=1 },
                new Contact { Id = 2, PersonalMail = "Shain@gmail.com", ProMail = "Shain@projet2", PersonalPhone = 078965558, ProPhone = 061234566,  AdressId = 2 },
                new Contact { Id = 3, PersonalMail = "Monef@gmail.com", ProMail = "Moncef@projet2", PersonalPhone = 065547877, ProPhone = 061234566,  AdressId = 3 },
                new Contact { Id = 4, PersonalMail = "Wafa@gmail.com", ProMail = "Wafa@projet2", PersonalPhone = 0788229969, ProPhone = 061234566,  AdressId = 4 }
                );

            this.Adresses.AddRange(
              new Adress { Id = 1, Num = "2", Street ="rue odessa", PostalCode = 75 , City = "Paris" },
              new Adress { Id = 2, Num = "5", Street = "rue mondella", PostalCode = 95, City = "Paris" },
              new Adress { Id = 3, Num = "9", Street = "rue general de gaulle", PostalCode = 75, City = "Paris" },
              new Adress { Id = 4, Num = "1", Street = "rue ampere", PostalCode = 91, City = "Paris" }
              );
            this.ProfessionalInfos.AddRange(
               new ProfessionalInfo { Id = 1, Position = Position.SALARIE, Function = 0 },
               new ProfessionalInfo { Id = 2, Position = 0, Function = Function.DEVELOPPEUR },
               new ProfessionalInfo { Id = 3, Position = 0, Function = 0},
               new ProfessionalInfo { Id = 4, Position = Position.DIRECTEUR, Function = Function.DIRECTEUR_GENERAL }
               );

            this.Roles.AddRange(
               new Role { Id = 1, Type = Type.ADMIN },
               new Role { Id = 2, Type = Type.MANAGER },
               new Role { Id = 3, Type = Type.SALARIE }
               );

            
            this.Activities.AddRange(
              new Activity { Id = 1, Date = new DateTime(2023 , 02 , 01), Halfday = true, TypeActivity = TypeActivity.ASTREINTE},
              new Activity { Id = 2, Date = new DateTime(2023, 02, 01), Halfday = true, TypeActivity = TypeActivity.CongeMaternite },
              new Activity { Id = 3, Date = new DateTime(2023, 02, 01), Halfday = true, TypeActivity = TypeActivity.ASTREINTE},
              new Activity { Id = 4, TypeActivity = TypeActivity.ASTREINTE, Date = new DateTime(2023,05,26), Halfday = true }
              );
            this.CRAs.AddRange(
               new CRA { Id = 1, Date = new DateTime(2023, 02, 01), State = State.INCOMPLET, ActivityId = 1 },
               new CRA { Id = 2, Date = new DateTime(2023, 02, 01), State = State.NON_VALIDE, ActivityId = 2 },
               new CRA { Id = 3, Date = new DateTime(2023, 02, 01), State = State.VALIDE, ActivityId = 3 },
               new CRA { Id = 4, Date = new DateTime(2023, 02, 01), State = State.EN_COURS_DE_VALIDATION, ActivityId = 4 }

            );

            this.UserActivities.AddRange(
               new UserActivity { Id = 1, UserId = 1, ActivityId = 2 },
               new UserActivity { Id = 2, UserId = 2, ActivityId = 1},
               new UserActivity { Id = 3, UserId = 3, ActivityId = 1 },
               new UserActivity { Id = 4, UserId = 3, ActivityId = 2 });





            this.SaveChanges();


        }
    }
}
