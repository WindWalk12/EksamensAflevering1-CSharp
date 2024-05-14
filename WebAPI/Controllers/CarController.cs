using BusinessLogic;
using DTO.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet]
        [Route("GetCarById/{id}")]
        public Car GetCarById(int id)
        {
            return CarBLL.GetCarById(id);
        }

        [HttpPost]
        [Route("AddCar")]
        public void AddCar(Car car)
        {
            CarBLL.AddCar(car);
        }

        [HttpGet]
        [Route("GetAllCars")]
        public List<Car> GetAllCars()
        {
            return CarBLL.GetAllCars();
        }

        [HttpGet]
        [Route("GetCarDetails/{id}")]
        public Car GetCarDetails(int id)
        {
            return CarBLL.GetCarDetails(id);
        }
    }
}
