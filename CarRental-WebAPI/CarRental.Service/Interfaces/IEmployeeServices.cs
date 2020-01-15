using CarRental.Domain.EF.IRepositories;
using CarRental.Services.Interfaces;
namespace CarRental.Service.Interfaces
{
    public interface IEmployeeServices : IBaseServices
    {
        IEmployeeRepository EmployeeRepository { get; }
    }
}
