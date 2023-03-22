using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;

namespace NoviaReport.Controllers
{
    public class LoginController : Controller
    {
        private Dal dal;
        public LoginController()
        {
            dal = new Dal();
        }
        public IActionResult Index()
        {
            UserViewModel viewModel = new UserViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.User = dal.GetUser(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(UserViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User utilisateur = dal.Authentifier(viewModel.User.Login, viewModel.User.Password);
                if (utilisateur != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, utilisateur.Id.ToString())
                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("/");
                }
                ModelState.AddModelError("User.Login", "Login et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }
    }
}
