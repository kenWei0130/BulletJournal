using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BulletJournal.Models;
using BulletJournal.Services;

namespace BulletJournal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoService _todoService;

        public HomeController(ILogger<HomeController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _todoService.TodayTodoListAsync());
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
