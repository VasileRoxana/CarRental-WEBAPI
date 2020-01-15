
using CarRental.Domain.EF;
using CarRental.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services.Implementations
{
    public class BaseServices : IBaseServices
    {
        private readonly CarRentalDbContext _context;

        public BaseServices(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task CommitChanges()
        {
            await _context.SaveChangesAsync(true);
        }
    }
}
