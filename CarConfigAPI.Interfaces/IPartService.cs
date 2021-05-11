using System;
using System.Collections.Generic;
using System.Text;

namespace CarConfigAPI.Interfaces
{
    public interface IPartService
    {
        public List<Parts> GetAvailableCarParts(int id);
    }
}
