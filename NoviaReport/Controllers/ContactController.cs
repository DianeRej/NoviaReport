﻿using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;

namespace NoviaReport.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // GET : ContactController
        public IActionResult CreateContact()
        {
            using (DalContact dal = new DalContact())
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateContact(string personalMail, int personalPhone, string proMail,
            int proPhone, string street, int postalcode, string city)
        {
            if (!ModelState.IsValid)
                return View();
            using (DalContact dal = new DalContact())
            {
                dal.CreateContact(personalMail, personalPhone, proMail, proPhone, street, postalcode, city);

                return View();
            }
        }
    }
}
