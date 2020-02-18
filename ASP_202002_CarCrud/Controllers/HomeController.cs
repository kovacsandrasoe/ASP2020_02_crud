using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_202002_CarCrud.Models;

namespace ASP_202002_CarCrud.Controllers
{
    public class HomeController : Controller
    {
        CarLogic logic;

        public HomeController()
        {
            logic = new CarLogic();
        }

        public IActionResult Index()
        {
            return View();
        }

        //formot hozza be
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //form eredményeit kapja meg
        [HttpPost]
        public IActionResult Add(Car car)
        {
            logic.Add(car);
            return RedirectToAction(nameof(Dashboard));
        }

        public IActionResult Delete(string id)
        {
            logic.Delete(id);
            return RedirectToAction(nameof(Dashboard));
        }

        public IActionResult Dashboard()
        {
            //össszes autó mehet a viewnak!
            return View(logic.GetAll());
        }



    }
}
