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
        public DbSet<UserCRA> UserCRAs { get; set; }
        public DbSet<CRA> CRAs { get; set; }
        public DbSet<CraActivity> CraActivities { get; set; }
        public DbSet<Activity> Activities { get; set; }

        //lien vers la BDD
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseMySql("server=localhost;user id=root;password=soubass1950;database=noviaReport");
        }

        //Méthode différente que "?" pour dire que la valeur de cette table peut être nulle
        /* protected override void OnModelCreating(ModelBuilder modelBuilder) {
                  modelBuilder.Entity<Activity>().Property(m => m.Absences).IsRequired(false);
                  base.OnModelCreating(modelBuilder); }*/

        //Initialisation de la BDD avec des données type pour faire des tests, elles seront bien sûr à remplacer
        //avec des données plus crédibles à la fin 
        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            //mock données de Users
            this.Users.AddRange(
                new User { Id = 1, Firstname = "Diane", Lastname = "Reja", Login = "DianeR", Password = DalUser.EncodeMD5("ddddd"), ContactId = 1, ProfessionalInfoId = 1 },
                new User { Id = 2, Firstname = "Shain", Lastname = "Arbam", Login = "ShainA", Password = DalUser.EncodeMD5("sssss"), ContactId = 2, ProfessionalInfoId = 2 },
                new User { Id = 3, Firstname = "Moncef", Lastname = "Said", Login = "MoncefS", Password = DalUser.EncodeMD5("mmmmm"), ContactId = 3, ProfessionalInfoId = 3, ManagerId = 2 },
                new User { Id = 4, Firstname = "Wafa", Lastname = "Ayeb", Login = "WafaA", Password = DalUser.EncodeMD5("wwwww"), ContactId = 4, ProfessionalInfoId = 4, ManagerId = 2 }
                );

            this.Contacts.AddRange(
                new Contact { Id = 1, Street = "2 rue odessa", PostalCode = 75, City = "Paris", PersonalMail = "Diane@gmail.com", ProMail = "Diane@projet2", PersonalPhone = 061234566, ProPhone = 061234566 },
                new Contact { Id = 2, Street = "5 rue mondella", PostalCode = 95, City = "Paris", PersonalMail = "Shain@gmail.com", ProMail = "Shain@projet2", PersonalPhone = 078965558, ProPhone = 061234566 },
                new Contact { Id = 3, Street = "9 rue general de gaulle", PostalCode = 75, City = "Paris", PersonalMail = "Monef@gmail.com", ProMail = "Moncef@projet2", PersonalPhone = 065547877, ProPhone = 061234566 },
                new Contact { Id = 4, Street = "1 rue ampere", PostalCode = 91, City = "Paris", PersonalMail = "Wafa@gmail.com", ProMail = "Wafa@projet2", PersonalPhone = 0788229969, ProPhone = 061234566 }
                );

            this.ProfessionalInfos.AddRange(
               new ProfessionalInfo { Id = 1, Position = Position.NONCADRE, Function = Function.RH, DateOfArrival = new DateTime(2013, 10, 01) },
               new ProfessionalInfo { Id = 2, Position = Position.CADRE, Function = Function.DEVELOPPEUR, DateOfArrival = new DateTime(2014, 12, 29) },
               new ProfessionalInfo { Id = 3, Position = Position.CADRE, Function = Function.INGENIEUR, DateOfArrival = new DateTime(2013, 02, 28) },
               new ProfessionalInfo { Id = 4, Position = Position.DIRECTEUR, Function = Function.DIRECTEUR_GENERAL, DateOfArrival = new DateTime(2010, 01, 31) }
               );

            this.Roles.AddRange(
               new Role { Id = 1, TypeRole = TypeRole.ADMIN, UserId = 1 },
               new Role { Id = 2, TypeRole = TypeRole.MANAGER, UserId = 2 },
               new Role { Id = 3, TypeRole = TypeRole.SALARIE, UserId = 3 },
               new Role { Id = 4, TypeRole = TypeRole.SALARIE, UserId = 4 },
               new Role { Id = 5, TypeRole = TypeRole.MANAGER, UserId = 4 }
               );


            //mock données de CRA

            this.UserCRAs.AddRange(
                new UserCRA { Id = 1, UserId = 1, CRAId = 1 },
                new UserCRA { Id = 2, UserId = 2, CRAId = 2 },
                new UserCRA { Id = 3, UserId = 3, CRAId = 3 },
                new UserCRA { Id = 4, UserId = 4, CRAId = 4 },

                new UserCRA { Id = 5, UserId = 1, CRAId = 5 },
                new UserCRA { Id = 6, UserId = 2, CRAId = 6 },
                new UserCRA { Id = 7, UserId = 3, CRAId = 7 },
                new UserCRA { Id = 8, UserId = 4, CRAId = 8 },

                new UserCRA { Id = 9, UserId = 1, CRAId = 9 },
                new UserCRA { Id = 10, UserId = 2, CRAId = 10 },
                new UserCRA { Id = 11, UserId = 3, CRAId = 11 },
                new UserCRA { Id = 12, UserId = 4, CRAId = 12 },

                new UserCRA { Id = 13, UserId = 1, CRAId = 13 },
                new UserCRA { Id = 14, UserId = 2, CRAId = 14 },
                new UserCRA { Id = 15, UserId = 3, CRAId = 15 },
                new UserCRA { Id = 16, UserId = 4, CRAId = 16 }                                
                );

            this.CRAs.AddRange(

                new CRA { Id = 1, Date = new DateTime(2023, 01, 01), State = State.VALIDE },
                new CRA { Id = 2, Date = new DateTime(2023, 01, 01), State = State.VALIDE },
                new CRA { Id = 3, Date = new DateTime(2023, 01, 01), State = State.VALIDE },
                new CRA { Id = 4, Date = new DateTime(2023, 01, 01), State = State.VALIDE },

                new CRA { Id = 5, Date = new DateTime(2023, 02, 01), State = State.INCOMPLET },
                new CRA { Id = 6, Date = new DateTime(2023, 02, 01), State = State.INCOMPLET },
                new CRA { Id = 7, Date = new DateTime(2023, 02, 01), State = State.INCOMPLET },
                new CRA { Id = 8, Date = new DateTime(2023, 02, 01), State = State.INCOMPLET },

                new CRA { Id = 9, Date = new DateTime(2023, 03, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 10, Date = new DateTime(2023, 03, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 11, Date = new DateTime(2023, 03, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 12, Date = new DateTime(2023, 03, 01), State = State.EN_COURS_DE_VALIDATION },

                new CRA { Id = 13, Date = new DateTime(2023, 04, 01), State = State.NON_VALIDE },
                new CRA { Id = 14, Date = new DateTime(2023, 04, 01), State = State.NON_VALIDE },
                new CRA { Id = 15, Date = new DateTime(2023, 04, 01), State = State.NON_VALIDE },
                new CRA { Id = 16, Date = new DateTime(2023, 04, 01), State = State.NON_VALIDE }                
                );

            this.CraActivities.AddRange(
                new CraActivity { Id = 1, CRAId = 1, ActivityId = 1 },
                new CraActivity { Id = 2, CRAId = 1, ActivityId = 2 },
                new CraActivity { Id = 3, CRAId = 1, ActivityId = 3 },
                new CraActivity { Id = 4, CRAId = 1, ActivityId = 4 },
                new CraActivity { Id = 5, CRAId = 2, ActivityId = 5 },
                new CraActivity { Id = 6, CRAId = 2, ActivityId = 6 },
                new CraActivity { Id = 7, CRAId = 2, ActivityId = 7 },
                new CraActivity { Id = 8, CRAId = 2, ActivityId = 8 },
                new CraActivity { Id = 9, CRAId = 3, ActivityId = 9 },
                new CraActivity { Id = 10, CRAId = 3, ActivityId = 10 },
                new CraActivity { Id = 11, CRAId = 4, ActivityId = 11 },
                new CraActivity { Id = 12, CRAId = 4, ActivityId = 12 },
                new CraActivity { Id = 13, CRAId = 4, ActivityId = 13 }
                );


            this.Activities.AddRange(
                new Activity { Id = 1, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client2 },
                new Activity { Id = 2, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client2 },
                new Activity { Id = 3, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client2 },
                new Activity { Id = 4, Date = new DateTime(2023, 02, 26), TypeActivity = TypeActivity.CongéPayé },
                new Activity { Id = 5, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client1 },
                new Activity { Id = 6, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client1 },
                new Activity { Id = 7, Date = new DateTime(2023, 02, 03), Halfday = true, TypeActivity = TypeActivity.PRESTATION, Client = Client.Client3 },
                new Activity { Id = 8, Date = new DateTime(2023, 02, 03), Halfday = true, TypeActivity = TypeActivity.FORMATION_PROFESSIONNELLE },
                new Activity { Id = 9, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client4 },
                new Activity { Id = 10, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client4 },
                new Activity { Id = 11, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.CongeMaternite },
                new Activity { Id = 12, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.CongeMaternite },
                new Activity { Id = 13, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.MAINTENANCE, Client = Client.Client4 }
                );

            this.SaveChanges();

        }
    }
}
