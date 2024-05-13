using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Mappers
{
    internal class GuestMapper
    {
        public static DTO.Model.Guest Map(Guest guest)
        {
            return new DTO.Model.Guest(guest.Id, guest.Name, guest.Sex, guest.CarId, guest.FerryId);
        }
        public static Guest Map(DTO.Model.Guest guest)
        {
            return new Guest(guest.Id, guest.Name, guest.Sex, guest.CarId, guest.FerryId);
        }

        public static List<DTO.Model.Guest> Map(List<Guest> guests)
        {
            List<DTO.Model.Guest> guestsList = new List<DTO.Model.Guest>();
            foreach (Guest guest in guests)
            {
                guestsList.Add(GuestMapper.Map(guest));
            }
            return guestsList;
        }

        public static List<Guest> Map(List<DTO.Model.Guest> guests)
        {
            List<Guest> guestsList = new List<Guest>();
            foreach (DTO.Model.Guest guest in guests)
            {
                guestsList.Add(GuestMapper.Map(guest));
            }
            return guestsList;
        }
    }
}
