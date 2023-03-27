using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using System;
using System.Collections.Generic;

namespace NoviaReport.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        [Authorize]
        public IActionResult SeeUsers()
        {
            DalUser dal = new DalUser();
            List<User> users = dal.GetAllUsers();
            return View("UserList",users);
        }

    }
}

