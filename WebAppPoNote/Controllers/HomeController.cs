using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppPoNote.Models;
using WebAppPoNote.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebAppPoNote.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<WebAppPoNoteUser> _UserManager;
       public HomeController(ILogger<HomeController> logger, UserManager<WebAppPoNoteUser> UserManager)
        {
            _logger = logger;
            _UserManager = UserManager;
        }

        public IActionResult Index()
        {
            return View();
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
