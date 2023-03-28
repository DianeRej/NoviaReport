using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NoviaReport.Models.DAL_IDAL;
using System;

namespace NoviaReport.Models
{
    public class BddContext : DbContext
    {
        //public BddContext() { //pour debug
            
        //    Console.WriteLine("instanciation");
        //}


        //Tables du User
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ProfessionalInfo> ProfessionalInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        //Tables liées au CRA
        public DbSet<CRA> CRAs { get; set; }
        public DbSet<Activity> Activities{ get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }

        //lien vers la BDD
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=noviaReport");
        }

        //Méthode différente que "?" pour dire que la valeur de cette table peut être nulle
                /* protected override void OnModelCreating(ModelBuilder modelBuilder) {
                          modelBuilder.Entity<Activity>().Property(m => m.Absences).IsRequired(false);
                          base.OnModelCreating(modelBuilder); }*/

        //Initialisation de la BDD avec des données type pour faire des tests, elles seront bine sûr à remplacer
        //avec des données plus crédibles à la fin 
        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();


            this.Users.AddRange(
                new User { Id = 1, Firstname = "Diane", Lastname = "Reja", Login = "DianeR", Password = DalUser.EncodeMD5("ddddd"), ContactId = 1,  ProfessionalInfoId = 1 },
                new User { Id = 2, Firstname = "Shain", Lastname = "Arbam", Login = "ShainA", Password = DalUser.EncodeMD5("sssss"), ContactId = 2,  ProfessionalInfoId = 2 },
                new User { Id = 3, Firstname = "Moncef", Lastname = "Said", Login = "MoncefS", Password = DalUser.EncodeMD5("mmmmm"), ContactId = 3,  ProfessionalInfoId = 3 ,ManagerId=2},
                new User { Id = 4, Firstname = "Wafa", Lastname = "Ayeb", Login = "WafaA", Password = DalUser.EncodeMD5("wwwww"), ContactId = 4, ProfessionalInfoId = 4, ManagerId=2 }

                );
            


            this.Contacts.AddRange(
                new Contact { Id = 1, Street = "2 rue odessa", PostalCode = 75, City = "Paris", PersonalMail = "Diane@gmail.com", ProMail = "Diane@projet2", PersonalPhone = 061234566, ProPhone = 061234566},
                new Contact { Id = 2, Street = "5 rue mondella", PostalCode = 95, City = "Paris", PersonalMail = "Shain@gmail.com", ProMail = "Shain@projet2", PersonalPhone = 078965558, ProPhone = 061234566 },
                new Contact { Id = 3, Street = "9 rue general de gaulle", PostalCode = 75, City = "Paris", PersonalMail = "Monef@gmail.com", ProMail = "Moncef@projet2", PersonalPhone = 065547877, ProPhone = 061234566},
                new Contact { Id = 4, Street = "1 rue ampere", PostalCode = 91, City = "Paris" , PersonalMail = "Wafa@gmail.com", ProMail = "Wafa@projet2", PersonalPhone = 0788229969, ProPhone = 061234566}
                );

            this.ProfessionalInfos.AddRange(
               new ProfessionalInfo { Id = 1, Position = Position.NONCADRE, Function = Function.RH, DateOfArrival = new DateTime(2013, 10, 01) },
               new ProfessionalInfo { Id = 2, Position = Position.CADRE, Function = Function.DEVELOPPEUR, DateOfArrival = new DateTime(2014, 12, 29) },
               new ProfessionalInfo { Id = 3, Position = Position.CADRE, Function = Function.INGENIEUR, DateOfArrival = new DateTime(2013, 02, 28) },
               new ProfessionalInfo { Id = 4, Position = Position.DIRECTEUR, Function = Function.DIRECTEUR_GENERAL, DateOfArrival = new DateTime(2010, 01, 31) }
               );

            this.Roles.AddRange(
               new Role { Id = 1, TypeRole = TypeRole.ADMIN, UserId=1 },
               new Role { Id = 2, TypeRole = TypeRole.MANAGER, UserId = 2 },
               new Role { Id = 3, TypeRole = TypeRole.SALARIE, UserId = 3 },
               new Role { Id = 4, TypeRole = TypeRole.SALARIE, UserId = 4 },
               new Role { Id = 5, TypeRole = TypeRole.MANAGER, UserId = 4 }
               );

            this.CRAs.AddRange(
                new CRA { Id = 1, Date = new System.DateTime(01/02/2013), State =State.INCOMPLET, ActivityId =1 },
                new CRA { Id = 2, Date = new System.DateTime(23 / 03 / 2013), State = State.NON_VALIDE, ActivityId = 2 },
                new CRA { Id = 3, Date = new System.DateTime(12 / 04 / 2013), State = State.VALIDE, ActivityId = 3 },
                new CRA { Id = 4, Date = new System.DateTime(20 / 05 / 2013), State = State.EN_COURS_DE_VALIDATION, ActivityId = 4 }

                );

            this.Activities.AddRange(
               new Activity { Id = 1, Date = new System.DateTime(01 / 02 / 2013),Halfday = true, Absences = Absences.CongéMaladie, OtherActivities = OtherActivities.FORMATION_PROFESSIONNELLE },
               new Activity { Id = 2, OtherActivities = OtherActivities.INTER_CONTRAT },
               new Activity { Id = 3, CustomersServices = CustomersServices.PRESTATION },
               new Activity { Id = 4, Date = new System.DateTime(20 / 05 / 2013), Halfday = true, Absences = Absences.ExamenMédicalDuTravail, CustomersServices = CustomersServices.PRESTATION }
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
