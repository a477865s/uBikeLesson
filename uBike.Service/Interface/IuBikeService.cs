using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uBike.Service.Dto;

namespace uBike.Service.Interface
{
    public interface IuBikeService
    {
        List<YouBikeStationsDto> GetStations();
    }
}
