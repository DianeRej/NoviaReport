using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using System;

namespace NoviaReport.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult SeeProfiles()
        {
            Dal dal = new Dal();
            ViewData["ProfileList"] = dal.GetAllProfiles();
            return View("ProfileList");
        }
    }

}
