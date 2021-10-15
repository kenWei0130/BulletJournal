using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OnPost()
        {
            return View();
        }
    }
}
