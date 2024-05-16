using DataAccess.Repositories;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class CarBLL
    {
        public static Car GetCarById(int id)
        {
            return CarRepository.GetCar(id);
        }

        public static void AddCar(Car car)
        {
            CarRepository.AddCar(car);
        }

        public static List<Car> GetAllCars()
        {
            return CarRepository.GetCars();
        }

        public static Car GetCarDetails(int id)
        {
            return CarRepository.GetCarDetails(id);
        }

        public static void DeleteCar(Car car)
        {
            CarRepository.DeleteCar(car);
        }
    }
}
