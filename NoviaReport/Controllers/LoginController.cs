using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using NoviaReport.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;

namespace NoviaReport.Controllers
{
    public class LoginController : Controller
    {
        private DalUser dal;
        public LoginController()
        {
            dal = new DalUser();
        }
        //Page de connexion (affiche le login si on est déjà connecté) 
        public IActionResult Index()
        {
            UserViewModel viewModel = new UserViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.User = dal.GetUser(HttpContext.User.Identity.Name);
                return View("EspaceLogin", viewModel);
            }
            return View("EspaceLogin", viewModel);
        }

        //post de la page de login, permet d'envoyer les infos de co (va générer un cookie qui permet de savoir si l'utilisateur est connecté)
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

                    HttpContext.SignInAsync(userPrincipal); //génère le cookie qui indique que l'utilisateur est connecté

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("/");
                }
                ModelState.AddModelError("User.Login", "Login et/ou mot de passe incorrect(s)");
            }
            return Redirect("/User/ListUserCRA");
        }
    }
}
