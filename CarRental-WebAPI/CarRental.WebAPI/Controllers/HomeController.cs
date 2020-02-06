using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Domain.EF.IRepositories;
using Microsoft.AspNetCore.Mvc;
using CarRental.Domain.Models.ViewModels;
using CarRental.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.WebAPI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly ICarRepository _carRepository;

        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public HomeController(ICarRepository carRepository, 
                              IHostingEnvironment hostingEnvironment ) {
            _carRepository = carRepository;
            this.hostingEnvironment = hostingEnvironment;
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
        public IActionResult Create(CarCreateViewModel model)
        {
            // check if we have valid data in the form
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Car newCar = new Car
                {
                    CarName = model.CarName,
                    VehicleClass = model.VehicleClass,
                    Capacity = model.Capacity,
                    CarType = model.CarType,
                    Price = model.Price,
                    PhotoPath = uniqueFileName
                    // Store the file name in PhotoPath property of the car object
                    // which gets saved to the Cars database table
                };

                _carRepository.Add(newCar);
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
                car.CarName = model.CarName;
                car.VehicleClass = model.VehicleClass;
                car.Capacity = model.Capacity;
                car.CarType = model.CarType;
                car.Price = model.Price;

                if (model.Photo != null)
                {
                    //if (model.ExistingPhotoPath != null)
                    //{
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "img", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    //}
                    car.PhotoPath = ProcessUploadedFile(model);
                }

                _carRepository.Add(car);
                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadedFile(CarCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.CreateNew));
            }

            return uniqueFileName;
        }
    }
 }
