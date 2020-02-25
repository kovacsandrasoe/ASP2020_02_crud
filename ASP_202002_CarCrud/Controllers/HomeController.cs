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

        public HomeController(CarLogic logic)
        {
            this.logic = logic;
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
        public async Task<IActionResult> Add(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            //guid == generate unique identifyer
            car.Id = Guid.NewGuid().ToString();
            

            //képkezelés
            car.ContentType = car.PhotoForm.ContentType;

            car.PhotoData = new byte[car.PhotoForm.Length];
            using (var stream = car.PhotoForm.OpenReadStream())
            {
                await stream.ReadAsync(car.PhotoData, 0, (int)car.PhotoForm.Length);
            }

            logic.Add(car);

            return RedirectToAction(nameof(Dashboard));
        }

        public IActionResult Delete(string id)
        {
            logic.Delete(id);
            return RedirectToAction(nameof(Dashboard));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var carToEdit = logic.GetAll()
                .FirstOrDefault(t => t.Id == id);
            return View(carToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            var carToEdit = logic.GetAll()
                .FirstOrDefault(t => t.Id == car.Id);
            carToEdit.Model = car.Model;
            carToEdit.Price = car.Price;
            logic.Save();
            return RedirectToAction(nameof(Dashboard));
        }



        public IActionResult Dashboard()
        {
            //össszes autó mehet a viewnak!
            return View(logic.GetAll());
        }

        public FileContentResult GetImage(string id)
        {
            var car = logic.GetAll()
                .FirstOrDefault(t => t.Id == id);
            return new 
                FileContentResult(car.PhotoData, car.ContentType);
        }




    }
}
