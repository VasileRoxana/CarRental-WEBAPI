using CarRental.Domain.EF.IRepositories;
using CarRental.Services.Interfaces;

namespace CarRental.Service.Interfaces
{
    public interface ICustomerServices : IBaseServices
    {
        ICustomerRepository CustomerRepository { get; }
    }
}
