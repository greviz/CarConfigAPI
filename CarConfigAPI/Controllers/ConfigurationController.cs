using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CarConfigAPI.Services;
using System.Linq;

namespace CarConfigAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        public readonly ConfigurationService configurationService;
        public ConfigurationController(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        [HttpPost("/configuration/save")]
        public int saveConfiguration([FromBody] Configurations body)
        {
            return configurationService.SaveConfiguration(body);
        }


        [HttpGet("/configuration/{id}")]
        public ActionResult<Configurations> getConfigurationById(int id)
        {
            return configurationService.GetConfigurationById(id);
        }

        [HttpGet("/configuration/user/{id}")]
        public ActionResult<List<Configurations>> getConfigurationsByUserId(int id)
        {
            return configurationService.GetConfigurationsByUserId(id);
        }

        [HttpGet("/configuration/all")]
        public ActionResult<List<Configurations>> getAllConfigurations()
        {
            return configurationService.GetAllConfigurations();
        }

        [HttpGet("/configuration/{id}/parts")]
        public ActionResult<List<Parts>> getConfigurationPartsByConfigurationId(int id)
        {
            return configurationService.GetConfigurationPartsByConfigurationId(id);
        }
    }
}