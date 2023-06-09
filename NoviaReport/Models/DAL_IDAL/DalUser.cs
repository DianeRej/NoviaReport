﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using NoviaReport.Models;
using Microsoft.EntityFrameworkCore;
using NoviaReport.Models.DAL_IDAL.Interfaces;



namespace NoviaReport.Models.DAL_IDAL
{
    public class DalUser : IDalUser
    {
        private BddContext _bddContext;

        //permet d'instancier le bddcontext (donc le lien vers la bdd)
        //on utilise cette méthode dans le controller à chaque fois que l'on veut appeler une méthode la dal
        public DalUser()
        {
            _bddContext = new BddContext();
        }

        //on ajoute une ligne dans la table User, on passe un user à la méthode
        public int CreateUser(User user)
        {
            //comme un user peut avoir ou non un manager, dans le formulaire on a une liste déroulante avec la liste des managers
            //et la ligne Aucun Manager, cette ligne renvoie un ManagerId=0.Il n'existe pas dans la table, donc pourêtre cohérent
            //dans la table il faut que cette valeur soit égale à null
            if (user.ManagerId == 0)
            {
                user.ManagerId = null;
            }
            //sert à encoder le password directement dans la table
            user.Password = EncodeMD5(user.Password);
            //une fois les modif faites aux données reçues initialement du formulaire on peut enregistrer le user dans la table
            _bddContext.Users.Add(user);
            _bddContext.SaveChanges();
            return user.Id;
        }

        //exactement le même principe que la création sauf qu'ici on passe en argument l'id du user, pour connaitre sa ligne dans la table
        public void UpdateUser(int id, User user)
        {
            if (user.ManagerId == 0)
            {
                user.ManagerId = null;
            }
            user.Password = EncodeMD5(user.Password);
            _bddContext.Users.Update(user);
            _bddContext.SaveChanges();
        }

        //pas encore utilisée, peut être à modifier 
        public void DeleteUser(int id)
        {
            User userToDelete = _bddContext.Users.Find(id);
            _bddContext.Users.Remove(userToDelete);
            _bddContext.SaveChanges();

        }

        

        //permet de chercher un user dans la table grâce à son id
        public User GetUserById(int id)
        {
            return this._bddContext.Users.Include(u => u.Contact).Include(u => u.ProfessionalInfo).SingleOrDefault(u => u.Id == id);
        }
        //permet de chercher un user dans la table grâce à son id (de type string et non int)
        public User GetUser(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetUserById(id);
            }
            return null;
        }

        //renvoie la liste de tous les users
        public List<User> GetAllUsers()
        {
            return _bddContext.Users
                .Include(u => u.ProfessionalInfo)
                //.Include(u => u.Role)
                .ToList();

        }
        //renvoie la liste de tous les users qui possèdent le rôle manager
        public List<User> GetManagers()
        {
            var query = from role in _bddContext.Roles
                        join user in _bddContext.Users on role.UserId equals user.Id
                        where role.TypeRole.Equals(TypeRole.MANAGER) //correspond à un utilisateur Manager
                        select user;
            List<User> managers = query.ToList();

            return managers;
        }

        //Methode pour afficher la liste des utilisateurs et leur CRA
        public List<UserCRA> GetUserCRA()
        {
            return _bddContext.UserCRAs.Include(uc => uc.User).Include(uc => uc.CRA).ToList();
        }

        //Méthode pour afficher les CRA lié à un utilisateur grace au Id
        public List<UserCRA> GetCRAForOneUser(int Id)

        {
            List<UserCRA> userCRAs = _bddContext.UserCRAs.Include(uc => uc.CRA).Include(ca => ca.User).Where(ca => ca.UserId == Id).ToList();
            return userCRAs;
        }


        public List<User> GetEmployeesOfAManager(int id)
        {
            List<User> employees = _bddContext.Users.Where(u=>u.ManagerId == id).ToList();
            return employees;
        }

        //méthode GetManagers qui exclut un manager de la liste s'il est lui même manager
        //(pour qu'à la modification d'un user il ne puisse pas s'auto-sélectionner)
        //public List<User> GetManagersWithExlusion(int id)
        //{
        //    var query = from role in _bddContext.Roles
        //                join user in _bddContext.Users on role.UserId equals user.Id
        //                where role.TypeRole.Equals(TypeRole.MANAGER) //correspond à un utilisateur Manager
        //                select user;
        //    List<User> managers = query.ToList();

        //    //on regarde si le user renseigné est manager
        //    //si c'est le cas on parcourt la liste jusqu'à le retrouver et on l'exclut de la liste
        //    User userToTest = GetUserById(id);
        //    if (userToTest.Role.Equals(TypeRole.MANAGER))
        //    {
        //        foreach (var manager in managers)
        //        {
        //            if (manager.Id == userToTest.Id)
        //            {
        //                managers.Remove(manager);
        //                break;
        //            }
        //        }
        //    }
        //    return managers;
        //}


        //méthode qui est appelée par le post de la page de connexion
        public User Authentifier(string login, string password)
        {
            string encodedPassword = EncodeMD5(password);
            User user = this._bddContext.Users.FirstOrDefault(u => u.Login == login && u.Password == encodedPassword);
            return user;
        }

        //Encodage du MdP
        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
