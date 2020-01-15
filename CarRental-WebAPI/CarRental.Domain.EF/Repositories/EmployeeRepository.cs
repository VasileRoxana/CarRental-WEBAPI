using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;

namespace CarRental.Domain.EF.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CarRentalDbContext context) : base(context)
        {
        }
    }
}
