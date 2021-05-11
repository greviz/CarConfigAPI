using CarConfigAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarConfigAPI.Services
{
    public class PartService : IPartService
    {
        private readonly CarConfigApiContext dbContext;

        public PartService(CarConfigApiContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Parts> GetAvailableCarParts(int id)
        {
            List<AvailableCarParts> ids = dbContext.AvailableCarParts.Where(c => c.CarId == id).ToList();
            List<Parts> output = new List<Parts>();
            foreach (AvailableCarParts carPartsId in ids)
            {
                Parts partById = dbContext.Parts.Where(p => p.Id == carPartsId.PartId).FirstOrDefault();
                if (partById != null)
                {
                    output.Add(partById);
                }
            }
            return output;
        }
    }
}
