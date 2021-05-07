using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarConfigAPI.Controllers
{
    [ApiController]

    public class CarController : ControllerBase
    {
        CarConfigApiContext dbContext;
        public CarController()
        {
            dbContext = new CarConfigApiContext();
        }

        [HttpGet("/car/{id}")]
        public Cars getCarById(int id)
        {
            return dbContext.Cars.Where(c => c.Id == id).FirstOrDefault();
        }

        [HttpGet("/car/allnew")]
        public List<Cars> getNewCars()
        {
            return dbContext.Cars.Where(c => c.Unused == true).ToList();
        }
    }
}
