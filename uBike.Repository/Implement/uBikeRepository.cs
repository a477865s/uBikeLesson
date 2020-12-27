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
        //使用HttpClient工廠 
        //private IHttpClientFactory _httpClientFactory;
        //public uBikeRepository(IHttpClientFactory client)
        //{
        //    this._httpClientFactory = client;
        //}
        
        public List<YouBikeStationModel> GetStations()
        {        
            var originalData = this.GetFirst();

            if (originalData == null || originalData.ReturnCode != 1)
            {
                return new List<YouBikeStationModel>();
            }

            var stations = new List<YouBikeStationModel>();

            foreach (var item in originalData.ReturnValue.PropertyValues())
            {
                //item內為多筆物件陣列，從YouBikeOriginalModel逐一進行物件序列化之後再反序列化到StationModel的collections模型裡
                var youbikemodel = JsonConvert.DeserializeObject<YouBikeStationModel>(item.ToString());
                stations.Add(youbikemodel);
            }

            //var stations = originalData.ReturnValue.PropertyValues()
            //                           .Where(item => item.HasValues)
            //                           .Select
            //                           (
            //                               item => JsonConvert.DeserializeObject<YouBikeStationModel>
            //                               (
            //                                   item.ToString()
            //                               )
            //                           )
            //                           .ToList();

            return stations;
        }

        /// <summary>
        /// 取得 YouBike 原始 API 資料.
        /// </summary>
        /// <returns>List&lt;YouBikeStationModel&gt;.</returns>
        private YouBikeOriginalModel GetFirst()
        {
            //var httpClient = _httpClientFactory.CreateClient("YouBike");

            //var data = httpClient.GetStringAsync(DataSource).GetAwaiter().GetResult();

            WebClient webClient= new WebClient();

            //轉型為UTF-8
            webClient.Encoding = System.Text.Encoding.UTF8;

            //取得json字串
            var result = webClient.DownloadString(DataSource);


            //反序列化成物件
            var answer=JsonConvert.DeserializeObject<YouBikeOriginalModel>(result);

            //回傳最初的整個json物件
            return answer;
                
        }
    }    
}
