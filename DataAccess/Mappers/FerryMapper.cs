using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Mappers
{
    internal class FerryMapper
    {
        public static DTO.Model.Ferry Map(Ferry ferry)
        {
            return new DTO.Model.Ferry(ferry.Id, ferry.Name, ferry.MaxCars, ferry.PricePerGuest, ferry.PricePerCar);
        }
        public static Ferry Map(DTO.Model.Ferry ferry)
        {
            return new Ferry(ferry.Id, ferry.Name, ferry.MaxCars, ferry.PricePerGuest, ferry.PricePerCar);
        }

        public static List<DTO.Model.Ferry> Map(List<Ferry> ferries)
        {
            List<DTO.Model.Ferry> ferriesList = new List<DTO.Model.Ferry>();
            foreach (Ferry ferry in ferries)
            {
                ferriesList.Add(FerryMapper.Map(ferry));
            }
            return ferriesList;
        }

        public static void Update(DTO.Model.Ferry ferry, Ferry dataemp)
        {
            dataemp.PricePerCar = ferry.PricePerCar;
            dataemp.PricePerGuest = ferry.PricePerGuest;
            dataemp.MaxCars = ferry.MaxCars;
            if (ferry.MaxGuests >= ferry.MaxCars * 5)
            {
                dataemp.MaxGuests = ferry.MaxGuests;
            }
        }

        public static DTO.Model.Ferry MapDetails(Ferry ferry)
        {
            DTO.Model.Ferry newFerry = new DTO.Model.Ferry();
            newFerry.Id = ferry.Id;
            newFerry.Name = ferry.Name;
            newFerry.PricePerCar = ferry.PricePerCar;
            newFerry.PricePerGuest = ferry.PricePerGuest;
            newFerry.MaxCars = ferry.MaxCars;
            newFerry.MaxGuests = ferry.MaxGuests;
            newFerry.Cars = CarMapper.Map(ferry.Cars);
            newFerry.Guests = GuestMapper.Map(ferry.Guests);
            return newFerry;
        }
    }
}
