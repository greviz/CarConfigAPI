using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarConfigAPI.Controllers
{
    [ApiController]
    public class PartsController : ControllerBase
    {
        CarConfigApiContext dbContext;

        public PartsController()
        {
            dbContext = new CarConfigApiContext();
        }

        [HttpGet("/parts/car/{id}")]
        public ActionResult<List<Parts>> getAvailableCarParts(long id)
        {
            
            List<AvailableCarParts> ids = dbContext.AvailableCarParts.Where(c => c.CarId == id).ToList();
            List<Parts> output = new List<Parts>();
            foreach(AvailableCarParts carPartsId in ids)
            {
                Parts partById = dbContext.Parts.Where(p => p.Id == carPartsId.PartId).FirstOrDefault();
                if (partById != null)
                {
                    output.Add(partById);
                }
            }
            return output;
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
