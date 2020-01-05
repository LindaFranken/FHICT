using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForumTry.Models;
using ForumTry.Repository;
using ForumTry.Models.Converters;

namespace ForumTry.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ForumRepository fr;

        public HomeController(ILogger<HomeController> logger, ForumRepository fr)
        {
            _logger = logger;
            this.fr = fr;
        }

        public IActionResult Index()
        {
            ForumViewModel fvm = new ForumViewModel();
            fvm.forumList = fr.GetAll();

            return View(fvm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ForumViewModel fvm = new ForumViewModel();

            return View(fvm);
        }

        [HttpPost]
        public IActionResult Create(ForumViewModel fvm)
        {
            TryValidateModel(fvm);
            ForumConvert fc = new ForumConvert();
            Forum f = fc.ConvertToModel(fvm);
            fr.Create(f);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
