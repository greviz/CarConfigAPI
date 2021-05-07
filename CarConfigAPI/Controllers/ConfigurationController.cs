using CarConfigAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarConfigAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        CarConfigApiContext dbContext;
        public ConfigurationController()
        {
            dbContext = new CarConfigApiContext();
        }

        [HttpPost("/configuration/save")]
        public int saveConfiguration([FromBody] ConfigurationsViewModel json)
        {

            return 1;
        } 


        [HttpGet("/configuration/{id}")]
        public ActionResult<ConfigurationViewModel> getConfigurationById(int id)
        {
            return dbContext.Configurations.Where(c => c.Id == id).FirstOrDefault();
        }

        [HttpGet("/configuration/user/{id}")]
        public ActionResult<List<ConfigurationViewModel>> getConfigurationsByUserId(int id)
        {
            return dbContext.Configurations.Where(c => c.CreatedBy == id).ToList();
        }

        [HttpGet("/configuration/all")]
        public ActionResult<List<ConfigurationViewModel>> getAllConfigurations()
        {
            return dbContext.Configurations.ToList();
        }
    }
}
