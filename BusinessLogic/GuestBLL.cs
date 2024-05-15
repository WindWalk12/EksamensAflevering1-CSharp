using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DTO.Model;

namespace BusinessLogic
{
    public static class GuestBLL
    {
        public static Guest GetGuestById(int id)
        {
            return GuestRepository.GetGuest(id);
        }

        public static Guest AddGuest(Guest guest)
        {
            GuestRepository.AddGuest(guest);
            return guest;
        }

        public static List<Guest> GetAllGuests()
        {
            return GuestRepository.GetGuests();
        }
    }
}
