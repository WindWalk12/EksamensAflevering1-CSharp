using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string NumberPlate { get; set; }
        public List<Guest> Guests { get; set; }
        public int FerryId { get; set; }

        public Car() { }

        public Car(int id, string numberPlate, int ferryId)
        {
            this.Id = id;
            this.NumberPlate = numberPlate;
            this.FerryId = ferryId;
        }

        public Car(string numberPlate, int ferryId)
        {
            this.NumberPlate = numberPlate;
            this.FerryId = ferryId;
        }
    }
}
