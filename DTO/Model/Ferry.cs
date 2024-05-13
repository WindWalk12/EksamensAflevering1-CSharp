using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Ferry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PricePerGuest { get; set; }
        public int PricePerCar { get; set; }
        public int MaxGuests { get; set; }
        public int MaxCars { get; set; }
        public List<Guest> Guests { get; set; }
        public List<Car> Cars { get; set; }

        public Ferry() { }

        public Ferry(int id, string name, int maxCars)
        {
            Id = id;
            Name = name;
            PricePerGuest = 99;
            PricePerCar = 197;
            MaxGuests = maxCars * 5 + 10;
            MaxCars = maxCars;
            Guests = new List<Guest>();
            Cars = new List<Car>();
        }

        public Ferry(string name, int maxCars)
        {
            Name = name;
            PricePerGuest = 99;
            PricePerCar = 197;
            MaxGuests = maxCars * 5 + 10;
            MaxCars = maxCars;
            Guests = new List<Guest>();
            Cars = new List<Car>();
        }
    }
}
