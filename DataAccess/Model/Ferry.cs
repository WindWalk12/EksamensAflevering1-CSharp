using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    internal class Ferry
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

        public Ferry(int id, string name, int maxCars, int pricePerGuest = 99, int pricePerCar = 197)
        {
            this.Id = id;
            this.Name = name;
            this.PricePerGuest = pricePerGuest;
            this.PricePerCar = pricePerCar;
            this.MaxGuests = maxCars*5+10;
            this.MaxCars = maxCars;
            this.Guests = new List<Guest>();
            this.Cars = new List<Car>();
        }

        public Ferry(string name, int maxCars, int pricePerGuest = 99, int pricePerCar = 197)
        {
            this.Name = name;
            this.PricePerGuest = pricePerGuest;
            this.PricePerCar = pricePerCar;
            this.MaxGuests = maxCars * 5 + 10;
            this.MaxCars = maxCars;
            this.Guests = new List<Guest>();
            this.Cars = new List<Car>();
        }
    }
}
