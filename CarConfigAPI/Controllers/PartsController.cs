using CarConfigAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarConfigAPI.Controllers
{
    [ApiController]
    public class PartsController : ControllerBase
    {
        public readonly PartService partService;

        public PartsController(PartService partService)
        {
            this.partService = partService;
        }

        [HttpGet("/parts/car/{id}")]
        public ActionResult<List<Parts>> getAvailableCarParts(int id)
        {
            return partService.GetAvailableCarParts(id);
        }
    }
}
