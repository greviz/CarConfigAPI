using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarConfigAPI.Controllers
{
    [Route("/car")]
    [ApiController]

    public class CarController : ControllerBase
    {
        CarConfigApiContext dbContext;
        public CarController()
        {
            dbContext = new CarConfigApiContext();
        }

        [HttpGet("allnew")]
        public List<Cars> getNewCars()
        {
            return dbContext.Cars.Where(c => c.Unused == true).ToList();
        }
    }
}
