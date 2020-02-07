using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;
using CarRental.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebAPI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public CarController(ICarRepository carRepository,
                              IHostingEnvironment hostingEnvironment)
        {
            _carRepository = carRepository;
            this.hostingEnvironment = hostingEnvironment;
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
                return RedirectToAction("Details", "Home", new { id = newCar.Id });
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
                    
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath, "img", model.ExistingPhotoPath);
                    System.IO.File.Delete(filePath);
                    car.PhotoPath = ProcessUploadedFile(model);
                    _carRepository.Update(car);
                    return RedirectToAction("index", "home");
                }
                else
                {
                    car.PhotoPath = "~/img/noaccess.jpg";
                }

                
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);

            if (car == null)
            {
                ViewBag.ErrorMessage = $"Car with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = _carRepository.Delete(id);

                if (result != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new NullReferenceException();
                }

                //return View("Index");
            }
        }

        private string ProcessUploadedFile(CarCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.CreateNew));
            }

            return uniqueFileName;
        }
    }
}
