using CarRental.Domain.EF;
using CarRental.Domain.EF.IRepositories;
using CarRental.Service.Interfaces;
using CarRental.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Service.Implementations
{
    public class EmployeeServices : BaseServices, IEmployeeServices
    {
        public IEmployeeRepository EmployeeRepository { get; }

        public EmployeeServices(CarRentalDbContext context, IEmployeeRepository employeeRepository) : base(context)
        {
            EmployeeRepository = employeeRepository;
        }

    }
}
