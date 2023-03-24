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
              DalProfile dal = new DalProfile();
              ViewData["ProfileList"] = dal.GetAllProfiles();
              return View("ProfileList");
         }

    }

    }

