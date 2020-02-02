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
                new Car(0, "Honda Civic", "B", 2000, "Sedan", 1000),
                new Car(1, "Mercedes AMG", "B", 6000, "Cabrio", 2216),
                new Car(2, "Lamborghini Murcielago", "B", 6000, "Sedan", 5126)
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
