using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int? CarId { get; set; }
        public int? FerryId { get; set; }

        public Guest() { }

        public Guest(int id, string name, string sex, int? carId, int? ferryId)
        {
            this.Id = id;
            this.Name = name;
            this.Sex = sex;
            this.CarId = carId;
            this.FerryId = ferryId;
        }

        public Guest(string name, string sex, int? carId, int? ferryId)
        {
            this.Name = name;
            this.Sex = sex;
            this.CarId = carId;
            this.FerryId = ferryId;
        }
    }
}
