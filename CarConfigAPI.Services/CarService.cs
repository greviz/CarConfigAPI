using CarConfigAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarConfigAPI.Services
{
    public class CarService : ICarService
    {
        private readonly CarConfigApiContext dbContext;
        public CarService(CarConfigApiContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Cars GetCarById(int carId)
        {
            return dbContext.Cars.Where(c => c.Id == carId).FirstOrDefault();
        }

        public List<Cars> GetAllNewCars()
        {
            return dbContext.Cars.Where(c => c.Unused == true).ToList();
        }
    }
}
