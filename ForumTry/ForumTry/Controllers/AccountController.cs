using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumTry.Models;
using ForumTry.Context.Interfaces;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace ForumTry.Controllers
{
    public class AccountController : Controller
    {
        private IAccountContext Ctx = null;

        public AccountController()
        {
            Ctx = new AccountContext();
        }
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel lvm = new LoginViewModel();
            return View(lvm);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel lvm)
        {
            AccountRepository ar = new AccountRepository(Ctx);
            TryValidateModel(lvm);
            if (ar.Login(lvm.Username, lvm.Password))
            {
                HttpContext.Session.SetString("Username", lvm.Username);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            RegisterViewModel rvm = new RegisterViewModel();

            return View(rvm);
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModel register)
        {
            TryValidateModel(register);
            AccountRepository rp = new AccountRepository(Ctx);
            rp.AddUser(register.Username, register.Password, register.Email);

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        //public IActionResult LoadUSers()
        //{
        //    return View();
        //}
    }
}