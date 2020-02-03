using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Domain.EF.IRepositories;
using Microsoft.AspNetCore.Mvc;
using CarRental.Domain.Models.ViewModels;
using CarRental.Domain.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly ICarRepository _carRepository;
        public HomeController(ICarRepository carRepository) {
            _carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var model = _carRepository.GetAllCars(); 
            return View(model); 
        }

        public ViewResult Details(int ? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Car = _carRepository.GetCarById(id ?? 1),
                PageTitle = "Car Details"
            };
            return View(homeDetailsViewModel);
        }

        // Get method for the create button from navbar
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        // Post method for creating a new car and displaying it
        [HttpPost]
        public IActionResult Create(Car car)
        {
            // check if we have valid data in the form
            if (ModelState.IsValid)
            {
                Car newCar = _carRepository.Add(car);
                return RedirectToAction("details", new { id = newCar.Id });
            }
            return View();
        }
    }
}
