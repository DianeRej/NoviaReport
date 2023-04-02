using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NoviaReport.Models.DAL_IDAL;
using System;

namespace NoviaReport.Models
{
    public class BddContext : DbContext
    {

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
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=noviaReport");
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
                new User { Id = 3, Firstname = "Moncef", Lastname = "Said", Login = "MoncefS", Password = DalUser.EncodeMD5("mmmmm"), ContactId = 3, ProfessionalInfoId = 3,},
                new User { Id = 4, Firstname = "Wafa", Lastname = "Ayeb", Login = "WafaA", Password = DalUser.EncodeMD5("wwwww"), ContactId = 4, ProfessionalInfoId = 4,},


                new User { Id = 5, Firstname = "Fidji", Lastname = "Kennedy", Login = "FidjiK", Password = DalUser.EncodeMD5("fifi"), ContactId = 5, ProfessionalInfoId = 5, ManagerId = 2},
                new User { Id = 6, Firstname = "Paul", Lastname = "Belmondo", Login = "PaulB", Password = DalUser.EncodeMD5("belo"), ContactId = 6, ProfessionalInfoId = 6, ManagerId=2},
                new User { Id = 7, Firstname = "Patrick", Lastname = "Brelle", Login = "PatrickB", Password = DalUser.EncodeMD5("brelle"), ContactId = 7, ProfessionalInfoId = 7, ManagerId = 2 },
                new User { Id = 8, Firstname = "Francis", Lastname = "Garbel", Login = "FrancisG", Password = DalUser.EncodeMD5("garbel"), ContactId = 8, ProfessionalInfoId = 8, ManagerId = 2 },

                new User { Id = 9, Firstname = "Alain", Lastname = "Decour", Login = "AlainD", Password = DalUser.EncodeMD5("alain"), ContactId = 9, ProfessionalInfoId = 9, ManagerId = 3 },
                new User { Id = 10, Firstname = "Pierre", Lastname = "Voisine", Login = "RokV", Password = DalUser.EncodeMD5("pierre"), ContactId = 10, ProfessionalInfoId = 10, ManagerId = 3 },
                new User { Id = 11, Firstname = "Viknesh", Lastname = "Mandu", Login = "VikneshM", Password = DalUser.EncodeMD5("viknesh"), ContactId = 11, ProfessionalInfoId = 11, ManagerId = 3 },
                new User { Id = 12, Firstname = "Sanjay", Lastname = "Talou", Login = "SanjayT", Password = DalUser.EncodeMD5("sanjay"), ContactId = 12, ProfessionalInfoId = 12, ManagerId = 3 },


                new User { Id = 13, Firstname = "Ashraaf", Lastname = "Awad", Login = "AshraafA", Password = DalUser.EncodeMD5("ashraaf"), ContactId = 13, ProfessionalInfoId = 13, ManagerId = 19 },
                new User { Id = 14, Firstname = "Athika", Lastname = "Fazil", Login = "AthikaF", Password = DalUser.EncodeMD5("athika"), ContactId = 14, ProfessionalInfoId = 14, ManagerId= 19 },
                new User { Id = 15, Firstname = "Sonia", Lastname = "Texeira",Login = "SoniaT", Password = DalUser.EncodeMD5("sonia"), ContactId = 15, ProfessionalInfoId = 15, ManagerId = 19 },
                new User { Id = 16, Firstname = "Lili", Lastname = "Baleine", Login = "LiliB", Password = DalUser.EncodeMD5("lili"), ContactId = 16, ProfessionalInfoId = 16, ManagerId = 20 },

                new User { Id = 17, Firstname = "Rosali", Lastname = "Tricoli", Login = "RosaliT", Password = DalUser.EncodeMD5("rosali"), ContactId = 17, ProfessionalInfoId = 17, ManagerId= 20 },
                new User { Id = 18, Firstname = "Violette", Lastname = "Celine",Login = "VioletteC", Password = DalUser.EncodeMD5("violette"), ContactId = 18, ProfessionalInfoId = 18, ManagerId= 20 },
                new User { Id = 19, Firstname = "Camaro", Lastname = "Ndialo", Login = "CamaroN", Password = DalUser.EncodeMD5("camaro"), ContactId = 19, ProfessionalInfoId = 19,},
                new User { Id = 20, Firstname = "Jay", Lastname = "Singh", Login = "JayS", Password = DalUser.EncodeMD5("jay"), ContactId = 20, ProfessionalInfoId = 20,},

                new User { Id = 21, Firstname = "Ashok", Lastname = "Lanka", Login = "AshokL", Password = DalUser.EncodeMD5("ashok"), ContactId = 21, ProfessionalInfoId = 21 }
                );

            this.Contacts.AddRange(
                new Contact { Id = 1, Street = "2 rue odessa", PostalCode = 75010, City = "Paris", PersonalMail = "Diane@gmail.com", ProMail = "Diane@projet2", PersonalPhone = 061234566, ProPhone = 061234566 },
                new Contact { Id = 2, Street = "5 rue mondella", PostalCode = 95130, City = "Paris", PersonalMail = "Shain@gmail.com", ProMail = "Shain@projet2", PersonalPhone = 078965558, ProPhone = 061234566 },
                new Contact { Id = 3, Street = "9 rue general de gaulle", PostalCode = 75008, City = "Paris", PersonalMail = "Monef@gmail.com", ProMail = "Moncef@projet2", PersonalPhone = 065547877, ProPhone = 061234566 },
                new Contact { Id = 4, Street = "1 rue ampere", PostalCode = 91020, City = "Paris", PersonalMail = "Wafa@gmail.com", ProMail = "Wafa@projet2", PersonalPhone = 0788229969, ProPhone = 061234566 },

                new Contact { Id = 5, Street = "28 rue barbusse", PostalCode = 75018, City = "Paris", PersonalMail = "FidjiK@gmail.com", ProMail = "FidjiK@projet2", PersonalPhone = 0612445566, ProPhone = 0612556644 },
                new Contact { Id = 6, Street = "10 rue de la paix", PostalCode = 06330, City = "Nice", PersonalMail = "paulB@gmail.com", ProMail = "paulB@projet2", PersonalPhone = 0789123456, ProPhone = 0712345634 },
                new Contact { Id = 7, Street = "19 rue du bon vent", PostalCode = 06150, City = "Nice", PersonalMail = "patrickB@gmail.com", ProMail = "PatrickB@projet2", PersonalPhone = 065547877, ProPhone = 0721345456 },
                new Contact { Id = 8, Street = "6 rue des paquettes", PostalCode = 06220, City = "Nice", PersonalMail = "FrancisG@gmail.com", ProMail = "FrancisG@projet2", PersonalPhone = 0728659969, ProPhone = 0657799881 },

                new Contact { Id = 9, Street = "35 rue des margerittes", PostalCode = 06360, City = "Eze", PersonalMail = "Alain@gmail.com", ProMail = "Alain@projet2", PersonalPhone = 063225544, ProPhone = 0644556677 },
                new Contact { Id = 10, Street = "20 rue de la station", PostalCode = 95130, City = "Franconville", PersonalMail = "PierreV@gmail.com", ProMail = "PierreV@projet2", PersonalPhone = 077776777, ProPhone = 075559988 },
                new Contact { Id = 11, Street = "10 rue kepler", PostalCode = 83600, City = "Frejus", PersonalMail = "Viknesh@gmail.com", ProMail = "Viknesh@projet2", PersonalPhone = 0766459887, ProPhone = 0743345645 },
                new Contact { Id = 12, Street = "1 rue du des jasmins", PostalCode =83160 , City = "la Mole", PersonalMail = "Sanjay@gmail.com", ProMail = "Sanjay@projet2", PersonalPhone = 0799999999, ProPhone = 0788009900 },

                new Contact { Id = 13, Street = "5 rue maurice meyer", PostalCode = 83980, City = "Le Lavandou", PersonalMail = "Ashraaf@gmail.com", ProMail = "Ashraaf@projet2", PersonalPhone = 0765344961, ProPhone = 0704050676 },
                new Contact { Id = 14, Street = "6 rue du general leclerc", PostalCode = 73220, City = "Aiton", PersonalMail = "Athika@gmail.com", ProMail = "Athika@projet2", PersonalPhone = 078965558, ProPhone = 061234566 },
                new Contact { Id = 15, Street = "7 rue de la poisse", PostalCode = 73100, City = "Aix-les-Bains", PersonalMail = "Sonia@gmail.com", ProMail = "Sonia@projet2", PersonalPhone = 065547877, ProPhone = 061234566 },
                new Contact { Id = 16, Street = "8 rue de la chance", PostalCode = 73410, City = "Albens", PersonalMail = "Lili@gmail.com", ProMail = "Lili@projet2", PersonalPhone = 0788229969, ProPhone = 061234566 },

                new Contact { Id = 17, Street = "1 rue rene jolie", PostalCode = 73700, City = "Arc 2000", PersonalMail = "Rosali@gmail.com", ProMail = "Rosali@projet2", PersonalPhone = 061234566, ProPhone = 061234566 },
                new Contact { Id = 18, Street = "2 rue cadet des veaux", PostalCode = 73210, City = "Belle Plagne", PersonalMail = "Violette@gmail.com", ProMail = "Violette@projet2", PersonalPhone = 078965558, ProPhone = 061234566 },
                new Contact { Id = 19, Street = "3 rue saint emillion", PostalCode = 06500, City = "Menton", PersonalMail = "Camaro@gmail.com", ProMail = "Camaro@projet2", PersonalPhone = 065547877, ProPhone = 061234566 },
                new Contact { Id = 20, Street = "4 rue saint michel", PostalCode = 75012, City = "Paris", PersonalMail = "Jay@gmail.com", ProMail = "Jay@projet2", PersonalPhone = 0633448877, ProPhone = 0623123456 },

                new Contact { Id = 21, Street = "4 rue bonaparte", PostalCode = 06230, City = "VilleFranche sur mer", PersonalMail = "Ashok@gmail.com", ProMail = "Ashok@projet2", PersonalPhone = 0788229969, ProPhone = 061234566 }


                );

            this.ProfessionalInfos.AddRange(
               new ProfessionalInfo { Id = 1, Position = Position.NONCADRE, Function = Function.RH, DateOfArrival = new DateTime(2012, 10, 01) },
               new ProfessionalInfo { Id = 2, Position = Position.DIRECTEUR, Function = Function.DIRECTEUR_COMMERCIAL, DateOfArrival = new DateTime(2010, 06, 01) },
               new ProfessionalInfo { Id = 3, Position = Position.CADRE, Function = Function.INGENIEUR, DateOfArrival = new DateTime(2010, 11, 28) },
               new ProfessionalInfo { Id = 4, Position = Position.DIRECTEUR, Function = Function.DIRECTEUR_GENERAL, DateOfArrival = new DateTime(2010, 01, 31) },

               new ProfessionalInfo { Id = 5, Position = Position.CADRE, Function = Function.DEVELOPPEUR, DateOfArrival = new DateTime(2011, 02, 01) },
               new ProfessionalInfo { Id = 6, Position = Position.CADRE, Function = Function.COMMERCIAL, DateOfArrival = new DateTime(2014, 04, 29) },
               new ProfessionalInfo { Id = 7, Position = Position.CADRE, Function = Function.COMMERCIAL, DateOfArrival = new DateTime(2014, 09, 28) },
               new ProfessionalInfo { Id = 8, Position = Position.CADRE, Function = Function.COMMERCIAL, DateOfArrival = new DateTime(2015, 02, 28) },

               new ProfessionalInfo { Id = 9, Position = Position.CADRE, Function = Function.DEVELOPPEUR, DateOfArrival = new DateTime(2015, 06, 01) },
               new ProfessionalInfo { Id = 10, Position = Position.CADRE, Function = Function.DEVELOPPEUR, DateOfArrival = new DateTime(2015, 09, 01) },
               new ProfessionalInfo { Id = 11, Position = Position.NONCADRE, Function = Function.TECHNICIEN, DateOfArrival = new DateTime(2016, 01, 28) },
               new ProfessionalInfo { Id = 12, Position = Position.NONCADRE, Function = Function.TECHNICIEN, DateOfArrival = new DateTime(2016, 10, 28) },
               
               new ProfessionalInfo { Id = 13, Position = Position.NONCADRE, Function = Function.RESPONSABLE_RESEAU, DateOfArrival = new DateTime(2010, 11, 01) },
               new ProfessionalInfo { Id = 14, Position = Position.NONCADRE, Function = Function.RESPONSABLE_RESEAU, DateOfArrival = new DateTime(2016, 12, 29) },
               new ProfessionalInfo { Id = 15, Position = Position.NONCADRE, Function = Function.RESPONSABLE_SECURITE, DateOfArrival = new DateTime(2015, 02, 28) },
               new ProfessionalInfo { Id = 16, Position = Position.CADRE, Function = Function.RESPONSABLE_SECURITE, DateOfArrival = new DateTime(2010, 01, 31) },

               new ProfessionalInfo { Id = 17, Position = Position.CADRE, Function = Function.CHEF_DE_PROJET, DateOfArrival = new DateTime(2016, 10, 01) },
               new ProfessionalInfo { Id = 18, Position = Position.CADRE, Function = Function.CHEF_DE_PROJET, DateOfArrival = new DateTime(2016, 12, 29) },
               new ProfessionalInfo { Id = 19, Position = Position.CADRE, Function = Function.INGENIEUR, DateOfArrival = new DateTime(2017, 02, 28) },
               new ProfessionalInfo { Id = 20, Position = Position.CADRE, Function = Function.INGENIEUR, DateOfArrival = new DateTime(2017, 01, 31) },
               
               new ProfessionalInfo { Id = 21, Position = Position.DIRECTEUR, Function = Function.PDG, DateOfArrival = new DateTime(2010, 01, 31) }
               );

            this.Roles.AddRange(
               new Role { Id = 1, TypeRole = TypeRole.MANAGER, UserId = 1 },
               new Role { Id = 2, TypeRole = TypeRole.MANAGER, UserId = 2 },

               new Role { Id = 3, TypeRole = TypeRole.MANAGER, UserId = 3 },
               new Role { Id = 4, TypeRole = TypeRole.MANAGER, UserId = 4 },
               
               new Role { Id = 5, TypeRole = TypeRole.ADMIN, UserId = 5 },
               new Role { Id = 6, TypeRole = TypeRole.SALARIE, UserId = 6 },
               new Role { Id = 7, TypeRole = TypeRole.SALARIE, UserId = 7 },
               new Role { Id = 8, TypeRole = TypeRole.SALARIE, UserId = 8 },
               
               new Role { Id = 9, TypeRole = TypeRole.SALARIE, UserId = 9 },
               new Role { Id = 10, TypeRole = TypeRole.SALARIE, UserId = 10 },              
               new Role { Id = 11, TypeRole = TypeRole.SALARIE, UserId = 11 },
               new Role { Id = 12, TypeRole = TypeRole.SALARIE, UserId = 12 },
               
               new Role { Id = 13, TypeRole = TypeRole.SALARIE, UserId = 13},
               new Role { Id = 14, TypeRole = TypeRole.SALARIE, UserId =  14 },              
               new Role { Id = 15, TypeRole = TypeRole.SALARIE, UserId = 15 },
               new Role { Id = 16, TypeRole = TypeRole.SALARIE, UserId =  16 },
               
               new Role { Id = 17, TypeRole = TypeRole.SALARIE, UserId = 17 },
               new Role { Id = 18, TypeRole = TypeRole.SALARIE, UserId =  18 },               
               new Role { Id = 19, TypeRole = TypeRole.MANAGER, UserId = 19 },
               new Role { Id = 20, TypeRole = TypeRole.MANAGER, UserId = 20 },

               new Role { Id = 21, TypeRole = TypeRole.MANAGER, UserId = 21 }
               );


            //mock données de CRA

            this.UserCRAs.AddRange(
                new UserCRA { Id = 1, UserId = 6, CRAId = 1 },
                new UserCRA { Id = 2, UserId = 7, CRAId = 2 },
                new UserCRA { Id = 3, UserId = 8, CRAId = 3 },
                new UserCRA { Id = 4, UserId = 9, CRAId = 4 },

                new UserCRA { Id = 5, UserId = 10, CRAId = 5 },
                new UserCRA { Id = 6, UserId = 11, CRAId = 6 },
                new UserCRA { Id = 7, UserId = 12, CRAId = 7 },
                new UserCRA { Id = 8, UserId = 13, CRAId = 8 },

                new UserCRA { Id = 9,  UserId = 14, CRAId = 9 },
                new UserCRA { Id = 10, UserId = 15, CRAId = 10 },
                new UserCRA { Id = 11, UserId = 16, CRAId = 11 },
                new UserCRA { Id = 12, UserId = 17, CRAId = 12 },

                new UserCRA { Id = 13, UserId = 18, CRAId = 13 },
                new UserCRA { Id = 14, UserId = 6, CRAId = 14 },
                new UserCRA { Id = 15, UserId = 7, CRAId = 15 },
                new UserCRA { Id = 16, UserId = 8, CRAId = 16 },

                new UserCRA { Id = 17, UserId = 9, CRAId = 17 },
                new UserCRA { Id = 18, UserId = 10, CRAId = 18 },
                new UserCRA { Id = 19, UserId = 11, CRAId = 19 },
                new UserCRA { Id = 20, UserId = 12, CRAId = 20 },

                new UserCRA { Id = 21, UserId = 13, CRAId = 21 },
                new UserCRA { Id = 22, UserId = 14, CRAId = 22 },
                new UserCRA { Id = 23, UserId = 15, CRAId = 23 },
                new UserCRA { Id = 24, UserId = 16, CRAId = 24 },

                new UserCRA { Id = 25, UserId = 17, CRAId = 25 },
                new UserCRA { Id = 26, UserId = 18, CRAId = 26 },
                new UserCRA { Id = 27, UserId = 6, CRAId = 27 },
                new UserCRA { Id = 28, UserId = 7, CRAId = 28 },

                new UserCRA { Id = 29, UserId = 8, CRAId = 29 },
                new UserCRA { Id = 30, UserId = 9, CRAId = 30 },
                new UserCRA { Id = 31, UserId = 10, CRAId = 31 },
                new UserCRA { Id = 32, UserId = 11, CRAId = 32 },

                new UserCRA { Id = 33, UserId = 12, CRAId = 33 },
                new UserCRA { Id = 34, UserId = 13, CRAId = 34 },
                new UserCRA { Id = 35, UserId = 14, CRAId = 35 },
                new UserCRA { Id = 36, UserId = 15, CRAId = 36 },

                new UserCRA { Id = 37, UserId = 16, CRAId = 37 },
                new UserCRA { Id = 38, UserId = 17, CRAId = 38 },
                new UserCRA { Id = 39, UserId = 18, CRAId = 39 },
                new UserCRA { Id = 40, UserId = 6, CRAId = 40 },

                new UserCRA { Id = 41, UserId = 7, CRAId = 41 },
                new UserCRA { Id = 42, UserId = 8, CRAId = 42 },
                new UserCRA { Id = 43, UserId = 9, CRAId = 43 },
                new UserCRA { Id = 44, UserId = 10, CRAId = 44 },

                new UserCRA { Id = 45, UserId = 11, CRAId = 45 },
                new UserCRA { Id = 46, UserId = 12, CRAId = 46 },
                new UserCRA { Id = 47, UserId = 13, CRAId = 47 },
                new UserCRA { Id = 48, UserId = 14, CRAId = 48 }

                );

            this.CRAs.AddRange(

                new CRA { Id = 1, Date = new DateTime(2023, 01, 01), State = State.VALIDE },
                new CRA { Id = 2, Date = new DateTime(2023, 01, 01), State = State.VALIDE },
                new CRA { Id = 3, Date = new DateTime(2023, 01, 01), State = State.VALIDE },
                new CRA { Id = 4, Date = new DateTime(2023, 01, 01), State = State.VALIDE },

                new CRA { Id = 5, Date = new DateTime(2023, 01, 01), State = State.INCOMPLET },
                new CRA { Id = 6, Date = new DateTime(2023, 01, 01), State = State.INCOMPLET },
                new CRA { Id = 7, Date = new DateTime(2023, 01, 01), State = State.INCOMPLET },
                new CRA { Id = 8, Date = new DateTime(2023, 01, 01), State = State.INCOMPLET },

                new CRA { Id = 9, Date = new DateTime(2023, 01, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 10, Date = new DateTime(2023, 01, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 11, Date = new DateTime(2023, 01, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 12, Date = new DateTime(2023, 01, 01), State = State.EN_COURS_DE_VALIDATION },

                new CRA { Id = 13, Date = new DateTime(2023, 01, 01), State = State.NON_VALIDE },
                new CRA { Id = 14, Date = new DateTime(2023, 02, 01), State = State.EN_COURS_DE_VALIDATION},
                new CRA { Id = 15, Date = new DateTime(2023, 02, 01), State = State.NON_VALIDE },
                new CRA { Id = 16, Date = new DateTime(2023, 02, 01), State = State.NON_VALIDE },

                new CRA { Id = 17, Date = new DateTime(2023, 02, 01), State = State.INCOMPLET },
                new CRA { Id = 18, Date = new DateTime(2023, 02, 01), State = State.INCOMPLET },
                new CRA { Id = 19, Date = new DateTime(2023, 02, 01), State = State.INCOMPLET },
                new CRA { Id = 20, Date = new DateTime(2023, 02, 01), State = State.INCOMPLET },

                new CRA { Id = 21, Date = new DateTime(2023, 02, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 22, Date = new DateTime(2023, 02, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 23, Date = new DateTime(2023, 02, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 24, Date = new DateTime(2023, 02, 01), State = State.EN_COURS_DE_VALIDATION },

                new CRA { Id = 25, Date = new DateTime(2023, 02, 01), State = State.NON_VALIDE },
                new CRA { Id = 26, Date = new DateTime(2023, 02, 01), State = State.NON_VALIDE },
                new CRA { Id = 27, Date = new DateTime(2023, 03, 01), State = State.NON_VALIDE },
                new CRA { Id = 28, Date = new DateTime(2023, 03, 01), State = State.NON_VALIDE },

                new CRA { Id = 29, Date = new DateTime(2023, 03, 01), State = State.INCOMPLET },
                new CRA { Id = 30, Date = new DateTime(2023, 03, 01), State = State.INCOMPLET },
                new CRA { Id = 31, Date = new DateTime(2023, 03, 01), State = State.INCOMPLET },
                new CRA { Id = 32, Date = new DateTime(2023, 03, 01), State = State.INCOMPLET },

                new CRA { Id = 33, Date = new DateTime(2023, 03, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 34, Date = new DateTime(2023, 03, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 35, Date = new DateTime(2023, 03, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 36, Date = new DateTime(2023, 03, 01), State = State.EN_COURS_DE_VALIDATION },

                new CRA { Id = 37, Date = new DateTime(2023, 03, 01), State = State.NON_VALIDE },
                new CRA { Id = 38, Date = new DateTime(2023, 12, 01), State = State.NON_VALIDE },
                new CRA { Id = 39, Date = new DateTime(2023, 12, 01), State = State.NON_VALIDE },
                new CRA { Id = 40, Date = new DateTime(2023, 12, 01), State = State.NON_VALIDE },

                new CRA { Id = 41, Date = new DateTime(2023, 12, 01), State = State.VALIDE },
                new CRA { Id = 42, Date = new DateTime(2023, 12, 01), State = State.VALIDE },
                new CRA { Id = 43, Date = new DateTime(2023, 12, 01), State = State.VALIDE },
                new CRA { Id = 44, Date = new DateTime(2023, 12, 01), State = State.VALIDE },

                new CRA { Id = 45, Date = new DateTime(2023, 12, 01), State = State.EN_COURS_DE_VALIDATION },
                new CRA { Id = 46, Date = new DateTime(2023, 12, 01), State = State.INCOMPLET },
                new CRA { Id = 47, Date = new DateTime(2023, 12, 01), State = State.INCOMPLET },
                new CRA { Id = 48, Date = new DateTime(2023, 12, 01), State = State.INCOMPLET }

                );

            this.CraActivities.AddRange(
                new CraActivity { Id = 1, CRAId = 1, ActivityId = 1 },
                new CraActivity { Id = 2, CRAId = 2, ActivityId = 2 },
                new CraActivity { Id = 3, CRAId = 3, ActivityId = 3 },
                new CraActivity { Id = 4, CRAId = 4, ActivityId = 4 },
                new CraActivity { Id = 5, CRAId = 5, ActivityId = 5 },
                new CraActivity { Id = 6, CRAId = 6, ActivityId = 6 },
                new CraActivity { Id = 7, CRAId = 7, ActivityId = 7 },
                new CraActivity { Id = 8, CRAId = 8, ActivityId = 8 },
                new CraActivity { Id = 9, CRAId = 9, ActivityId = 9 },
                new CraActivity { Id = 10, CRAId = 10, ActivityId = 10 },
                new CraActivity { Id = 11, CRAId = 11, ActivityId = 11 },
                new CraActivity { Id = 12, CRAId = 12, ActivityId = 12 },
                new CraActivity { Id = 13, CRAId = 13, ActivityId = 13 },

                new CraActivity { Id = 14, CRAId = 14, ActivityId = 14 },
                new CraActivity { Id = 15, CRAId = 15, ActivityId = 15 },
                new CraActivity { Id = 16, CRAId = 16, ActivityId = 16 },
                new CraActivity { Id = 17, CRAId = 17, ActivityId = 17 },
                new CraActivity { Id = 18, CRAId = 18, ActivityId = 18 },
                new CraActivity { Id = 19, CRAId = 19, ActivityId = 19 },
                new CraActivity { Id = 20, CRAId = 20, ActivityId = 20 },
                new CraActivity { Id = 21, CRAId = 21, ActivityId = 21 },
                new CraActivity { Id = 22, CRAId = 22, ActivityId = 22 },
                new CraActivity { Id = 23, CRAId = 23, ActivityId = 23 },
                new CraActivity { Id = 24, CRAId = 24, ActivityId = 24 },
                new CraActivity { Id = 25, CRAId = 25, ActivityId = 25 },
                new CraActivity { Id = 26, CRAId = 26, ActivityId = 26 },
                new CraActivity { Id = 27, CRAId = 27, ActivityId = 27 },
                new CraActivity { Id = 28, CRAId = 28, ActivityId = 28 },
                new CraActivity { Id = 29, CRAId = 29, ActivityId = 29 },
                new CraActivity { Id = 30, CRAId = 30, ActivityId = 30 },
                new CraActivity { Id = 31, CRAId = 31, ActivityId = 31 },
                new CraActivity { Id = 32, CRAId = 32, ActivityId = 32 },
                new CraActivity { Id = 33, CRAId = 33, ActivityId = 33 },
                new CraActivity { Id = 34, CRAId = 34, ActivityId = 34 },
                new CraActivity { Id = 35, CRAId = 35, ActivityId = 35 },
                new CraActivity { Id = 36, CRAId = 36, ActivityId = 36 },
              
                new CraActivity { Id = 37, CRAId = 37, ActivityId = 37 },
                new CraActivity { Id = 38, CRAId = 38, ActivityId = 38 },
                new CraActivity { Id = 39, CRAId = 39, ActivityId = 39 },
                new CraActivity { Id = 40, CRAId = 40, ActivityId = 40 },
                new CraActivity { Id = 41, CRAId = 41, ActivityId = 41 },
                new CraActivity { Id = 42, CRAId = 42, ActivityId = 42 },
                new CraActivity { Id = 43, CRAId = 43, ActivityId = 43 },
                new CraActivity { Id = 44, CRAId = 44, ActivityId = 44 },
                new CraActivity { Id = 45, CRAId = 45, ActivityId = 45 },
                new CraActivity { Id = 46, CRAId = 46, ActivityId = 46 },
                new CraActivity { Id = 47, CRAId = 47, ActivityId = 47 }
                );


            this.Activities.AddRange(
                new Activity { Id = 1, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client2 },
                new Activity { Id = 2, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client2 },
                new Activity { Id = 3, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client2 },
                new Activity { Id = 4, Date = new DateTime(2023, 02, 26), TypeActivity = TypeActivity.CONGE_PAYE },
                new Activity { Id = 5, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client1 },
                new Activity { Id = 6, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client1 },
                new Activity { Id = 7, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client3 },
                new Activity { Id = 8, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.FORMATION_PROFESSIONNELLE },
                new Activity { Id = 9, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client4 },
                new Activity { Id = 10, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client4 },
                new Activity { Id = 11, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.CONGE_MATERNITE },
                new Activity { Id = 12, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.CONGE_MATERNITE },
                new Activity { Id = 13, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.MAINTENANCE, Client = Client.Client4 },

                new Activity { Id = 14, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client9 },
                new Activity { Id = 15, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client9 },
                new Activity { Id = 16, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client9 },
                new Activity { Id = 17, Date = new DateTime(2023, 02, 26), TypeActivity = TypeActivity.CONGE_PAYE },
                new Activity { Id = 18, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client5 },
                new Activity { Id = 19, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client5 },
                new Activity { Id = 20, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client6 },
                new Activity { Id = 21, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.FORMATION_PROFESSIONNELLE },
                new Activity { Id = 22, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client6 },
                new Activity { Id = 23, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client7 },
                new Activity { Id = 24, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.CONGE_MATERNITE },
                new Activity { Id = 25, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.CONGE_MATERNITE },
                new Activity { Id = 26, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.MAINTENANCE, Client = Client.Client8 },
                new Activity { Id = 27, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client5 },
                new Activity { Id = 28, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client5 },

                new Activity { Id = 29, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.FORMATION_PROFESSIONNELLE },
                new Activity { Id = 30, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client4 },
                new Activity { Id = 31, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client4 },
                new Activity { Id = 32, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client6 },
                new Activity { Id = 33, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client6 },
                new Activity { Id = 34, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.MAINTENANCE, Client = Client.Client4 },

                new Activity { Id = 35, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client9 },
                new Activity { Id = 36, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client9 },
                new Activity { Id = 37, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.ASTREINTE, Client = Client.Client9 },
                new Activity { Id = 38, Date = new DateTime(2023, 02, 26), TypeActivity = TypeActivity.CONGE_PAYE },
                new Activity { Id = 39, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client5 },
                new Activity { Id = 40, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client5 },
                new Activity { Id = 41, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client6 },
                new Activity { Id = 42, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.FORMATION_PROFESSIONNELLE },
                new Activity { Id = 43, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client6 },
                new Activity { Id = 44, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client7 },
                new Activity { Id = 45, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client6 },
                new Activity { Id = 46, Date = new DateTime(2023, 02, 02), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client6 },
                new Activity { Id = 47, Date = new DateTime(2023, 02, 03), TypeActivity = TypeActivity.MAINTENANCE, Client = Client.Client8 },
                new Activity { Id = 48, Date = new DateTime(2023, 02, 01), TypeActivity = TypeActivity.PRESTATION, Client = Client.Client5 }
              
                );

            this.SaveChanges();

        }
    }
}
