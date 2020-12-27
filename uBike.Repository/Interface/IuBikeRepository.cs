using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uBike.Repository.Models;

namespace uBike.Repository.Interface
{
    public interface IuBikeRepository
    {
        List<YouBikeStationModel> GetStations();
    }
}
