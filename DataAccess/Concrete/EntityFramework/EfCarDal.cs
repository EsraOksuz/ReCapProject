using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            if (entity.BrandId > 5)
            {
                Console.WriteLine("Carbrand should be less than 5");
            }
            else if (entity.DailyPrice <= 0)
            {
                Console.WriteLine("Car price shoul be higher than 0");
            }
            else
            {
                using (CarContext context = new CarContext())
                {
                    var addedCar = context.Entry(entity);
                    addedCar.State = EntityState.Added;
                    context.SaveChanges();
                }
            }
        }

        public void Delete(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContext c = new CarContext())
            {
                return c.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContext c =new CarContext())
            {
                return filter == null ? c.Set<Car>().ToList() : c.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
