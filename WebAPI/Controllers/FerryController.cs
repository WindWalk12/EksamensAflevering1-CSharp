using BusinessLogic;
using DTO.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FerryController : ControllerBase
    {
        [HttpGet]
        [Route("GetFerryById/{id}")]
        public Ferry GetFerryById(int id)
        {
            return FerryBLL.GetFerryById(id);
        }

        [HttpPost]
        [Route("AddFerry")]
        public void AddFerry(Ferry ferry)
        {
            FerryBLL.AddFerry(ferry);
        }

        [HttpGet]
        [Route("GetAllFerries")]
        public List<Ferry> GetAllFerries()
        {
            return FerryBLL.GetAllFerries();
        }

        [HttpGet]
        [Route("GetFerryDetails/{id}")]
        public Ferry GetFerryDetails(int id)
        {
            return FerryBLL.GetFerryDetails(id);
        }

        [HttpPost]
        [Route("UpdateFerry")]
        public void UpdateFerry(Ferry ferry)
        {
            FerryBLL.UpdateFerry(ferry);
        }
    }
}
