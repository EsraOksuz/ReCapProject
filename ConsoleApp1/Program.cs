using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.BrandId);
            }


            Console.ReadLine();
        }
    }
}
