using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uBike.Repository.Models
{
    public class YouBikeOriginalModel
    {
        [JsonProperty("retCode")]
        public int ReturnCode { get; set; }

        [JsonProperty("retVal")]
        public JObject ReturnValue { get; set; }
    }
}
