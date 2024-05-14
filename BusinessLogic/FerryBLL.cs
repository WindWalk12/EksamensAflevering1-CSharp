using DataAccess.Repositories;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class FerryBLL
    {
        public static Ferry GetFerryById(int id)
        {
            return FerryRepository.GetFerry(id);
        }

        public static void AddFerry(Ferry ferry)
        {
            FerryRepository.AddFerry(ferry);
        }

        public static List<Ferry> GetAllFerries()
        {
            return FerryRepository.GetFerries();
        }

        public static Ferry GetFerryDetails(int id)
        {
            return FerryRepository.GetFerryDetails(id);
        }

        public static void UpdateFerry(Ferry ferry)
        {
            FerryRepository.UpdateFerry(ferry);
        }
    }
}
