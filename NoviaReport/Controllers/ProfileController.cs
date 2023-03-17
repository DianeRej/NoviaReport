﻿using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using System.Linq;

namespace NoviaReport.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateProfile()
        {
            using (IDal dal = new Dal())
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateProfile(string firstName, string lastName)
        {
            if (!ModelState.IsValid)
                return View();

            using (Dal dal = new Dal())
            {
                dal.CreateProfile(firstName, lastName);
                return Redirect("/home/seeProfiles");
            }

        }

        public IActionResult UpdateProfile(int id)
        {
            if (id != 0)
            {
                using (IDal dal = new Dal())
                {
                    Profile profile = dal.GetAllProfiles().Where(r => r.Id == id).FirstOrDefault();
                    if (profile == null)
                    {
                        return View("Error");
                    }
                    return View(profile);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult UpdateProfile(Profile profile)
        {
            if (!ModelState.IsValid)
                return View(profile);

            if (profile.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.UpdateProfile(profile);
                    return Redirect("/home/seeProfiles");
                }
            }
            else
            {
                return View("Error");
            }
        }
    }
}
