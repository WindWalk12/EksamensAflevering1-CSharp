using DataAccess.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccess.Mappers;

namespace DataAccess.Repositories
{
    public class FerryRepository
    {
        public static Ferry GetFerry(int id)
        {
            using (Context.Context context = new Context.Context())
            {
                return FerryMapper.Map(context.Ferries.Find(id));
            }
        }

        public static void AddFerry(Ferry ferry)
        {
            using (Context.Context context = new Context.Context())
            {
                context.Ferries.Add(FerryMapper.Map(ferry));
                context.SaveChanges();
            }
        }

        public static List<Ferry> GetFerries()
        {
            using (Context.Context context = new Context.Context())
            {
                return FerryMapper.Map(context.Ferries.ToList());
            }
        }

        public static Ferry GetFerryDetails(int id)
        {
            using (Context.Context context = new Context.Context())
            {
                IQueryable<Model.Ferry> ferry = context.Ferries.Where(f => f.Id == id).Include(f => f.Guests).Include(f => f.Cars);
                if (ferry.Count() == 1)
                {
                    return FerryMapper.MapDetails(ferry.First());
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public static void UpdateFerry(Ferry ferry)
        {
            using (Context.Context context = new Context.Context())
            {
                Model.Ferry dataFerry = context.Ferries.Find(ferry.Id);
                FerryMapper.Update(ferry, dataFerry);
                context.SaveChanges();
            }
        }
    }
}
