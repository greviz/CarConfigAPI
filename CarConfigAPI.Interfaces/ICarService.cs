using System;
using System.Collections.Generic;
using System.Text;

namespace CarConfigAPI.Interfaces
{
    public interface ICarService
    {
        public Cars GetCarById(int carId);
        public List<Cars> GetAllNewCars();
    }
}
