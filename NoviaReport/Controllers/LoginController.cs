using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NoviaReport.Models;
using NoviaReport.Models.DAL_IDAL;
using NoviaReport.ViewModels;
using System.Collections.Generic;
using System.Linq;
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
                User user = dal.Authentifier(viewModel.User.Login, viewModel.User.Password);
                List<Role> roles = new List<Role>();
                using (DalRole dalRole = new DalRole())
                {
                    roles = dalRole.GetRolesByUserId(user.Id);
                }

                if (user != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                    };

                    foreach (Role role in roles)
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, role.TypeRole.ToString()));
                    }

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });

                    HttpContext.SignInAsync(userPrincipal); //génère le cookie qui indique que l'utilisateur est connecté

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    if (roles.Where(r=>r.TypeRole==TypeRole.ADMIN).FirstOrDefault()!=null)
                    {
                        return Redirect("/Dashboard/DashboardAdmin");
                    }
                    else if (roles.Where(r => r.TypeRole == TypeRole.MANAGER).FirstOrDefault() != null)
                    {
                        return Redirect("/Dashboard/DashboardManager/" + user.Id);
                    }
                    else
                    {
                        return Redirect("/Dashboard/DashboardSalarie/"+ user.Id);
                    }
                }
                ModelState.AddModelError("User.Login", "Login et/ou mot de passe incorrect(s)"); //affiche l'erreur en cas de fausse saisie
            }
            return Redirect("/");
        }

        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
