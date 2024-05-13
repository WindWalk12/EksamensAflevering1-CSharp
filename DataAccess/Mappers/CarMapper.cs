using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Mappers
{
    internal class CarMapper
    {
        public static DTO.Model.Car Map(Car car)
        {
            return new DTO.Model.Car(car.Id, car.NumberPlate, car.FerryId);
        }
        public static Car Map(DTO.Model.Car car)
        {
            return new Car(car.Id, car.NumberPlate, car.FerryId);
        }

        public static DTO.Model.Car MapDetails(Car car)
        {
            DTO.Model.Car newCar = new DTO.Model.Car();
            newCar.Id = car.Id;
            newCar.NumberPlate = car.NumberPlate;
            newCar.Guests = GuestMapper.Map(car.Guests);
            newCar.FerryId = car.FerryId;
            return newCar;
        }

        public static List<DTO.Model.Car> Map(List<Car> cars)
        {
            List<DTO.Model.Car> carsList = new List<DTO.Model.Car>();
            foreach (Car car in cars)
            {
                carsList.Add(CarMapper.Map(car));
            }
            return carsList;
        }
    }
}
