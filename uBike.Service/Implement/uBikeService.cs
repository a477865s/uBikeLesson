using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uBike.Repository.Interface;
using uBike.Repository.Models;
using uBike.Service.Dto;
using uBike.Service.Interface;

namespace uBike.Service.Implement
{
    public class uBikeService : IuBikeService
    {
        //注入
        private IMapper Mapper;
        private IuBikeRepository _iuBikeRepository;

        public uBikeService(IuBikeRepository IuBikeRepository,IMapper mapper)
        {
            this._iuBikeRepository = IuBikeRepository;
            this.Mapper = mapper;

        }
        //取得站別內所有資料
        public List<YouBikeStationsDto> GetStations()
        {
            var DataResult=this._iuBikeRepository.GetStations();

            //使用AutoMapper
            var result=this.Mapper.Map<List<YouBikeStationModel>, List<YouBikeStationsDto>>(DataResult);
            return result;


        }
    }
}
