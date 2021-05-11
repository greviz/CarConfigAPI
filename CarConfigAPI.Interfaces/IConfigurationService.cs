using System;
using System.Collections.Generic;
using System.Text;

namespace CarConfigAPI.Interfaces
{
    public interface IConfigurationService
    {
        public int SaveConfiguration(Configurations body);
        public Configurations GetConfigurationById(int id);
        public List<Configurations> GetConfigurationsByUserId(int id);
        public List<Configurations> GetAllConfigurations();
        public List<Parts> GetConfigurationPartsByConfigurationId(int id);
    }
}
