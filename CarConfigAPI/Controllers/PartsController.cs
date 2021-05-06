using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarConfigAPI.Controllers
{
    [Route("/parts")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        CarConfigApiContext dbContext;

        public PartsController()
        {
            dbContext = new CarConfigApiContext();
        }

        //[HttpGet("car/{id}")]
        //public ActionResult<List<Parts>> getPartsByCarId(int id)
        //{
        //    var query = from part in dbContext.Parts
        //                where part.AvailableCarParts.Any(cp => cp.CarId == id)
        //                select part;
        //    //dbContext.Parts.SelectMany<>
        //    return Ok;

        //}
    }
}
