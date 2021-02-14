using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var c in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(c.Descriptions);
            }
            
            Console.ReadLine();
        }
    }
}
