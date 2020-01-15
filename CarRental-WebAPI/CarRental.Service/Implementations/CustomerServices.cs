using CarRental.Domain.EF;
using CarRental.Domain.EF.IRepositories;
using CarRental.Service.Interfaces;
using CarRental.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Service.Implementations
{
    public class CustomerServices : BaseServices, ICustomerServices
    {
        public ICustomerRepository CustomerRepository { get; }

        public CustomerServices(CarRentalDbContext context, ICustomerRepository customerRepository) : base(context)
        {
            CustomerRepository = customerRepository;
        }
    }
}
