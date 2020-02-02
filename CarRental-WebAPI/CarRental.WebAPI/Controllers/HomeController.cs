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

        public ViewResult Details(int Id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Car = _carRepository.GetCarById(Id),
                PageTitle = "Car Details"
            };
            return View(homeDetailsViewModel);
        }

        //public ViewResult Index()
        //{
        //    var model = _carRepository.GetAllAsync();
        //    return View(model);
        //}

        //public ViewResult Details(int id)
        //{
        //    HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
        //    {
        //        Car = _carRepository.GetCarById(id),
        //        PageTitle = "Car Details"
        //    };
        //return View(homeDetailsViewModel);
        //}
    }
}
