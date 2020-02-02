using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.EF
{
    public class MockCar : ICarRepository
    {
        private List<Car> _carList;

        public MockCar()
        {
            _carList = new List<Car>()
            {
                new Car(0, "Honda", "sag", 2000, "qhas", 252),
                new Car(1, "sah", "hash", 24, "hafj", 216),
                new Car(2, "Sxha", "asg", 51, "yhsd", 126)
            };
        }
        public Car GetCarById(int Id)
        {
            return _carList[Id];
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carList;
        }
        public Task<Car> CreateAsync(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> GetByCondition(Expression<Func<Car, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Car Update(Car entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
