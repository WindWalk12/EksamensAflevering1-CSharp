using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    internal class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public Guest() { }

        public Guest(int id, string name, string sex)
        {
            this.Id = id;
            this.Name = name;
            this.Sex = sex;
        }

        public Guest(string name, string sex)
        {
            this.Name = name;
            this.Sex = sex;
        }
    }
}
