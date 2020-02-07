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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.WebAPI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly ICarRepository _carRepository;
        private readonly UserManager<IdentityUser> userManager;

        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public HomeController(ICarRepository carRepository, 
                              IHostingEnvironment hostingEnvironment,
                              UserManager<IdentityUser> userManager) {
            _carRepository = carRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _carRepository.GetAllCars();
            ViewBag.userId = userManager.GetUserId(HttpContext.User);
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

        
    }
 }
