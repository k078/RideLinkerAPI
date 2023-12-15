using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using RideLinkerAPI.Data;

namespace RideLinkerAPI.Services
{
    public class CarService
    {
        private readonly RideLinkerDbContext _dbContext;

        public CarService(RideLinkerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Car> GetAllCars()
        {
            return _dbContext.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _dbContext.Cars.FirstOrDefault(car => car.id == id);
        }

        public void AddCar(Car newCar)
        {
            _dbContext.Cars.Add(newCar);
            _dbContext.SaveChanges();
        }

        public void UpdateCar(int id, Car updatedCar)
        {
            Car existingCar = _dbContext.Cars.FirstOrDefault(car => car.id == id);

            if (existingCar != null)
            {
                existingCar.brand = updatedCar.brand;
                existingCar.img = updatedCar.img;
                existingCar.locationId = updatedCar.locationId;
                existingCar.available = updatedCar.available;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteCar(int id)
        {
            Car carToRemove = _dbContext.Cars.FirstOrDefault(car => car.id == id);

            if (carToRemove != null)
            {
                _dbContext.Cars.Remove(carToRemove);
                _dbContext.SaveChanges();
            }
        }
    }
}
