using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DTO.Model;

namespace BusinessLogic
{
    public class GuestBLL
    {
        public static Guest GetGuest(int id)
        {
            return GuestRepository.GetGuest(id);
        }

        public static void AddGuest(Guest guest)
        {
            GuestRepository.AddGuest(guest);
        }

        public static List<Guest> GetAllGuests()
        {
            return GuestRepository.GetGuests();
        }
    }
}
