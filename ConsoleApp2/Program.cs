using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //ColorTest();
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

            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine(c.CarId + "---" + c.CarName + "---" + c.BrandName + "---" + c.ColorName + "---" + c.DailyPrice);
            }
        }
    }
}
