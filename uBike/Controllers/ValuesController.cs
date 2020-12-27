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
    public class ValuesController : ApiController
    {
        private IuBikeService _iuBikeService;
        public ValuesController(IuBikeService iuBikeService)
        {
            this._iuBikeService = iuBikeService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<YouBikeStationsDto> Get()
        {
            var stations = this._iuBikeService.GetStations();
            return stations;
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
