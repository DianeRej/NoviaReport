using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models.DAL_IDAL;
using System;

namespace NoviaReport.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult SeeUsers()
        {
            DalUser dal = new DalUser();
            ViewData["UserList"] = dal.GetAllUsers();
            return View("UserList");
        }

    }
}

