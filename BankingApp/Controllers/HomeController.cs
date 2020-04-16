using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankingApp.Models;
using ApplicationLogic.Services.Interfaces;

namespace BankingApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        ILog _log;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ILog log)
        {
            _log = log;
        }

        public IActionResult Index()
        {
            _log.info("Executing /home/index");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cards()
        {
            return View();
        }

        public IActionResult Transactions()
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
