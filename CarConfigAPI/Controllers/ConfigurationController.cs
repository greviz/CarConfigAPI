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
        public int saveConfiguration([FromBody] ConfigurationViewModel json)
        {
            json.CreatedOn = DateTime.Now;
            List<ConfigurationParts> partsIds = json.ConfigurationParts;
            json.CarId = json.Car.Id;
            json.CreatedBy = json.CreatedByNavigation.Id;
            json.Car = null;
            json.CreatedByNavigation = null;
            json.ConfigurationParts = null;
            dbContext.Configurations.Add(json);

            dbContext.SaveChanges();

            foreach (ConfigurationParts cp in partsIds)
            {
                ConfigurationParts temp = new ConfigurationParts
                {
                    ConfigurationId = json.Id,
                    PartId = cp.Id
                };
                dbContext.ConfigurationParts.Add(temp);
            }
            dbContext.SaveChanges();

            return json.Id;
        }


        [HttpGet("/configuration/{id}")]
        public ActionResult<ConfigurationViewModel> getConfigurationById(int id)
        {
            ConfigurationViewModel x = dbContext.Configurations.Where(c => c.Id == id).FirstOrDefault();
            x.CreatedByNavigation = dbContext.Users.Where(u => u.Id == x.CreatedBy).FirstOrDefault();
            x.Car = dbContext.Cars.Where(c => c.Id == x.CarId).FirstOrDefault();

            return x;
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

        [HttpGet("/configuration/{id}/parts")]
        public ActionResult<List<Parts>> getConfigurationPartsByConfigurationId(int id)
        {
            List<ConfigurationParts> ids = dbContext.ConfigurationParts.Where(c => c.ConfigurationId == id).ToList();
            List<Parts> output = new List<Parts>();
            foreach (ConfigurationParts part in ids)
            {
                Parts partById = dbContext.Parts.Where(p => p.Id == part.PartId).FirstOrDefault();
                if (partById != null)
                {
                    output.Add(partById);
                }
            }
            return output;
        }
    }
}