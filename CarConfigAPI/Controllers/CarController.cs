using CarConfigAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarConfigAPI.Controllers
{
    [ApiController]
    public class CarController : ControllerBase
    {
        public readonly CarService carService;
        public CarController(CarService carService)
        {
            this.carService = carService;
        }

        [HttpGet("/car/{id}")]
        public Cars getCarById(int id)
        {
            return carService.GetCarById(id);
        }

        [HttpGet("/car/allnew")]
        public List<Cars> getNewCars()
        {
            return carService.GetAllNewCars();
        }
    }
}
