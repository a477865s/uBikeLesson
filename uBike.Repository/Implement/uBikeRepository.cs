using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using uBike.Repository.Interface;
using uBike.Repository.Models;

namespace uBike.Repository.Implement
{
    public class uBikeRepository : IuBikeRepository
    {

        private Uri DataSource => new Uri("https://tcgbusfs.blob.core.windows.net/blobyoubike/YouBikeTP.json");
        //private IHttpClientFactory _httpClientFactory;
        //public uBikeRepository(IHttpClientFactory client)
        //{
        //    this._httpClientFactory = client;
        //}
        
        public List<YouBikeStationModel> GetStations()
        {        
            var originalData = this.RetriveData();

            if (originalData == null || originalData.ReturnCode != 1)
            {
                return new List<YouBikeStationModel>();
            }

            var stations = originalData.ReturnValue.PropertyValues()
                                       .Where(item => item.HasValues)
                                       .Select
                                       (
                                           item => JsonConvert.DeserializeObject<YouBikeStationModel>
                                           (
                                               item.ToString()
                                           )
                                       )
                                       .ToList();

            return stations;
        }

        /// <summary>
        /// 取得 YouBike 原始 API 資料.
        /// </summary>
        /// <returns>List&lt;YouBikeStationModel&gt;.</returns>
        private YouBikeOriginalModel RetriveData()
        {
            //var httpClient = _httpClientFactory.CreateClient("YouBike");

            //var data = httpClient.GetStringAsync(DataSource).GetAwaiter().GetResult();

            WebClient webClient= new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            var result = webClient.DownloadString(DataSource);

            var answer=JsonConvert.DeserializeObject<YouBikeOriginalModel>(result);
            return answer;
                
        }
    }    
}
