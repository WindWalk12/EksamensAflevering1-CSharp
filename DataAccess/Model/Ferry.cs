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
        public List<Guest> Guests { get; set; }
        public List<Car> Cars { get; set; }

        public Ferry() { }

        public Ferry(int id, string name, List<Guest> guests, List<Car> cars)
        {
            this.Id = id;
            this.Name = name;
            PricePerGuest = 99;
            PricePerCar = 197;
            this.Guests = guests;
            this.Cars = cars;
        }

        public Ferry(string name, List<Guest> guests, List<Car> cars)
        {
            this.Name = name;
            PricePerGuest = 99;
            PricePerCar = 197;
            this.Guests = guests;
            this.Cars = cars;
        }
    }
}
