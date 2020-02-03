using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car(0, "Honda Civic", CarClass.B, 2000, CarType.Berlina, 1000),
                new Car(1, "Mercedes AMG", CarClass.B, 6000, CarType.Cabrio, 2216),
                new Car(2, "Lamborghini Murcielago", CarClass.B, 6000, CarType.Berlina, 5126)
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

        public Car Add(Car car)
        {
            car.Id = _carList.Max(c => c.Id) + 1;
            _carList.Add(car);
            return car;

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

        public Car Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
