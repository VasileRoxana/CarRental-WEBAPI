using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Domain.EF.IRepositories;
using Microsoft.AspNetCore.Mvc;
using CarRental.Domain.Models.ViewModels;
using CarRental.Domain.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.WebAPI.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly ICarRepository _carRepository;
        public HomeController(ICarRepository carRepository) {
            _carRepository = carRepository;
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _carRepository.GetAllCars(); 
            return View(model); 
        }

        [AllowAnonymous]
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
        // Get method for the create button from navbar
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Car car = _carRepository.GetCarById(id);
            CarEditViewModel carEditViewModel = new CarEditViewModel
            {
                Id = car.Id,
                CarName = car.CarName,
                VehicleClass = car.VehicleClass,
                Capacity = car.Capacity,
                CarType = car.CarType,
                Price = car.Price,
                ExistingPhotoPath = car.PhotoPath
            };

            return View(carEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(CarEditViewModel model)
        {
            // check if we have valid data in the form
            if (ModelState.IsValid)
            {
                Car car = _carRepository.GetCarById(model.Id);
                Console.WriteLine(car);
                car.Id = model.Id;
                car.CarName = model.CarName;
                car.VehicleClass = model.VehicleClass;
                car.Capacity = model.Capacity;
                car.CarType = model.CarType;
                car.Price = model.Price;
                if (model.PhotoPath != null)
                {
                    car.PhotoPath = model.PhotoPath;
                }
                else 
                    car.PhotoPath = model.ExistingPhotoPath;
                model.ExistingPhotoPath = model.PhotoPath;

                _carRepository.Update(car);
                return RedirectToAction("index");
            }
            return View();
        }
    }
 }
