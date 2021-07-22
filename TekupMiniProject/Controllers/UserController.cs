using TekupMiniProject.Models;
using TekupMiniProject.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;


namespace TekupMiniProject.Controllers
{
    public class UserController : Controller
    {
        public UserRepository UserRepository { get; }

        public UserController(UserRepository repository)
        {
            UserRepository = repository;
        }

        public IActionResult Inscription()
        {
            return View();
        }

        public IActionResult InscriptionSuccess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(User User)
        {
            try
            {
                UserRepository.Inscription(User);
                return RedirectToAction(nameof(InscriptionSuccess));
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult Authentication()
        {
            return View();
        }

        public IActionResult AuthenticationSuccess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authentication(User User)
        {
            try
            {
                UserRepository.Authentication(User);
                return RedirectToAction(nameof(AuthenticationSuccess));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
