﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId =1, ColorId=1, BrandId=1, DailyPrice =70000, ModelYear =1996, Descriptions="Benzinli"},
                new Car{CarId =2, ColorId=1, BrandId=1, DailyPrice =85000, ModelYear =2000, Descriptions="Benzinli"},
                new Car{CarId =3, ColorId=4, BrandId=2, DailyPrice =780000, ModelYear =2002, Descriptions="Dizel"},
                new Car{CarId =4, ColorId=2, BrandId=2, DailyPrice =650000, ModelYear =2010, Descriptions="Benzinli"},
                new Car{CarId =5, ColorId=3, BrandId=1, DailyPrice =170000, ModelYear =2020, Descriptions="Elektrikli"},

            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine(car.BrandId + " added successfully");
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
            Console.WriteLine(carToDelete.BrandId + " deleted successfully");
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Descriptions = car.Descriptions;

            Console.WriteLine(carToUpdate.BrandId + " updated successfully");
        }
    }
}
