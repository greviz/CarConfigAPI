using CarConfigAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarConfigAPI.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly CarConfigApiContext dbContext;
        public ConfigurationService(CarConfigApiContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int SaveConfiguration(Configurations body)
        {
            body.CreatedOn = DateTime.Now;
            List<ConfigurationParts> partsIds = body.ConfigurationParts;
            body.CarId = body.Car.Id;
            body.CreatedBy = body.CreatedByNavigation.Id;
            body.Car = null;
            body.CreatedByNavigation = null;
            body.ConfigurationParts = null;

            dbContext.Configurations.Add(body);
            dbContext.SaveChanges();

            foreach (ConfigurationParts cp in partsIds)
            {
                ConfigurationParts temp = new ConfigurationParts
                {
                    ConfigurationId = body.Id,
                    PartId = cp.Id
                };
                dbContext.ConfigurationParts.Add(temp);
            }
            dbContext.SaveChanges();

            return body.Id;
        }

        public Configurations GetConfigurationById(int id)
        {
            Configurations x = dbContext.Configurations.Where(c => c.Id == id).FirstOrDefault();
            x.CreatedByNavigation = dbContext.Users.Where(u => u.Id == x.CreatedBy).FirstOrDefault();
            x.Car = dbContext.Cars.Where(c => c.Id == x.CarId).FirstOrDefault();

            return x;
        }

        public List<Configurations> GetConfigurationsByUserId(int id)
        {
            List<Configurations> foundConfigurations = dbContext.Configurations.Where(c => c.CreatedBy == id).ToList();

            foreach (Configurations config in foundConfigurations)
            {
                config.Car = dbContext.Cars.Where(c => c.Id == config.CarId).FirstOrDefault();
            }

            return foundConfigurations;
        }

        public List<Configurations> GetAllConfigurations()
        {
            List<Configurations> foundConfigurations = dbContext.Configurations.ToList();

            foreach (Configurations config in foundConfigurations)
            {
                config.Car = dbContext.Cars.Where(c => c.Id == config.CarId).FirstOrDefault();
                config.CreatedByNavigation = dbContext.Users.Where(u => u.Id == config.CreatedBy).FirstOrDefault();
            }

            return foundConfigurations;
        }

        public List<Parts> GetConfigurationPartsByConfigurationId(int id)
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
