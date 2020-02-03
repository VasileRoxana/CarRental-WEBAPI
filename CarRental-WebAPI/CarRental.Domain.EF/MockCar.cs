using CarRental.Domain.EF.IRepositories;
using CarRental.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


// in memory Repository
namespace CarRental.Domain.EF
{
    public class MockCar : ICarRepository
    {
        private List<Car> _carList;

        public MockCar()
        {
            _carList = new List<Car>()
            {
                new Car(0, "Honda Civic", CarClass.B, 2000, CarType.Berlina, 1000,"https://cdn.motor1.com/images/mgl/VmvAB/s3/2020-honda-civic-type-r.jpg" ),
                new Car(1, "Mercedes AMG", CarClass.B, 6000, CarType.Cabrio, 2216,"https://www.autocar.co.uk/sites/autocar.co.uk/files/styles/body-image/public/911-road-3629a.jpg?itok=m6x23Go0" ),
                new Car(2, "Lamborghini Murcielago", CarClass.B, 6000, CarType.Berlina, 5126,"https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQAm1C05DaazFiRWcfM3m8FqayaOa-T64ushgHosW4gZwoJXUp1" )
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

        public Car Update(Car carChanges)
        {
            Car car = _carList.FirstOrDefault(e => e.Id == carChanges.Id);
            if (car != null)
            {
                car.CarName = carChanges.CarName;
                car.VehicleClass = carChanges.VehicleClass;
                car.Capacity = carChanges.Capacity;
                car.CarType = carChanges.CarType;
                car.Price = carChanges.Price;
            }
            return car;
        }

        public Car Delete(int Id)
        {
            Car car = _carList.FirstOrDefault(e => e.Id == Id);
            if (car != null)
            {
                _carList.Remove(car);
            }
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

    }
}
