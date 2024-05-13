using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    internal class Car
    {
        public int Id { get; set; }
        public string NumberPlate { get; set; }
        public List<Guest> Guests { get; set; }

        public Car() { }

        public Car(int id, string numberPlate, List<Guest> guests)
        {
            this.Id = id;
            this.NumberPlate = numberPlate;
            this.Guests = guests;
        }

        public Car(string numberPlate, List<Guest> guests)
        {
            this.NumberPlate = numberPlate;
            this.Guests = guests;
        }
    }
}
