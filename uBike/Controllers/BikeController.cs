using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using uBike.Service.Dto;
using uBike.Service.Interface;

namespace uBike.Controllers
{
    
    public class BikeController : ApiController
    {
        private IuBikeService _iuBikeService;
        public BikeController(IuBikeService iuBikeService)
        {
            this._iuBikeService = iuBikeService;
        } 
        [HttpGet]
        public IEnumerable<YouBikeStationsDto> GetAll()
        {
            var stations = this._iuBikeService.GetStations();
            return stations;
        }

    }
}
