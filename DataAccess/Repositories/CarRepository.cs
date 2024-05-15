using DataAccess.Mappers;
using DTO.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CarRepository
    {
        public static Car GetCar(int id)
        {
            using (Context.Context context = new Context.Context())
            {
                return CarMapper.Map(context.Cars.Find(id));
            }
        }

        public static void AddCar(Car car)
        {
            using (Context.Context context = new Context.Context())
            {
                context.Cars.Add(CarMapper.Map(car));
                context.SaveChanges();
            }
        }

        public static List<Car> GetCars()
        {
            using (Context.Context context = new Context.Context())
            {
                return CarMapper.Map(context.Cars.ToList());
            }
        }

        public static Car GetCarDetails(int id)
        {
            using (Context.Context context = new Context.Context())
            {
                IQueryable<Model.Car> car = context.Cars.Where(c => c.Id == id).Include(c => c.Guests);
                if (car.Count() == 1)
                {
                    return CarMapper.MapDetails(car.First());
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
