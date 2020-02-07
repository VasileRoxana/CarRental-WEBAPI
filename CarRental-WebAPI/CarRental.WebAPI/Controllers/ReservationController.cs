using CarRental.Domain.EF;
using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;
using CarRental.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebAPI.Controllers
{
    [Authorize(Roles = "User")]
    public class ReservationController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IReservationRepository _reservationRepository;
        public ReservationController(UserManager<IdentityUser> userManager, IReservationRepository reservationRepository)
        {
            this.userManager = userManager;
            this._reservationRepository = reservationRepository;
        }
        
        [HttpGet]
        public IActionResult ListReservations(string id)
        {
            List<Reservation> reservations = new List<Reservation>();
            reservations = _reservationRepository.GetReservationsByUserId(id);
            return View(reservations);
        }
        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
        public IActionResult Reservation(int id)
        {
            ReservationViewModel model = new ReservationViewModel
            {
                CarId = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ViewResult> ReservationAsync(ReservationViewModel reservationViewModel, int id)
        {
            // check if we have valid data in the form
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                Reservation newReservation = new Reservation
                {
                    UserId = user.Id,
                    CarId = id,
                    StartDate = reservationViewModel.StartDate,
                    EndDate = reservationViewModel.EndDate
                };

                _reservationRepository.Add(newReservation);
                return View("ReservationComplete");
            }
            return View();
        }

    }
}
