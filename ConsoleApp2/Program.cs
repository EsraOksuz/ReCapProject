using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            CarManager cm = new CarManager(new EfCarDal());
            CarContext cars = new CarContext();
            List<Car> carrs= cars.Cars.Where(p=>p.ColorId ==2).ToList();
            foreach (var color in carrs)
            {
                Console.WriteLine(color.CarId);
            }

            IDataResult<List<Car>> cr = (IDataResult<List<Car>>)cm.GetCarsByColorId(2);
            Console.WriteLine(cr);
            Console.ReadLine();           
            
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarId + "---" + c.CarName + "---" + c.BrandName + "---" + c.ColorName + "---" + c.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
