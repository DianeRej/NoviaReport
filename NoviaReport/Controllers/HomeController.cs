﻿using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models.DAL_IDAL;
using System;

namespace NoviaReport.Controllers
{
    public class HomeController : Controller
    {
        //page d'accueil 
        public IActionResult Index()
        {

            return View();
        }
<<<<<<< HEAD

=======
        //Permet d'afficher la liste des utilisateurs (Prénoms, Noms...) à continuer 
>>>>>>> Diane_Features2
        public IActionResult SeeUsers()
        {
            DalUser dal = new DalUser();
            ViewData["UserList"] = dal.GetAllUsers();
            return View("UserList");
        }

    }
}

