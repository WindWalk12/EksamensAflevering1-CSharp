using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccess.Mappers;

namespace DataAccess.Repositories
{
    public class GuestRepository
    {
        public static Guest GetGuest(int id)
        {
            using (Context.Context context = new Context.Context())
            {
                return GuestMapper.Map(context.Guests.Find(id));
            }
        }

        public static void AddGuest(Guest guest)
        {
            using (Context.Context context = new Context.Context())
            {
                context.Guests.Add(GuestMapper.Map(guest));
                context.SaveChanges();
            }
        }

        public static List<Guest> GetGuests()
        {
            using (Context.Context context = new Context.Context())
            {
                return GuestMapper.Map(context.Guests.ToList());
            }
        }

        public static void DeleteGuest(Guest guest)
        {
            using (Context.Context context = new Context.Context())
            {
                context.Guests.Remove(GuestMapper.Map(guest));
                context.SaveChanges();
            }
        }

        public static void DeleteGuests(List<Guest> guests)
        {
            using (Context.Context context = new Context.Context())
            {
                context.Guests.RemoveRange(GuestMapper.Map(guests));
                context.SaveChanges();
            }
        }
    }
}
