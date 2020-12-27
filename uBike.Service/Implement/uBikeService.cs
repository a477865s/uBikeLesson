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
        private IMapper Mapper;
        private IuBikeRepository _iuBikeRepository;
        public uBikeService(IuBikeRepository IuBikeRepository,IMapper mapper)
        {
            this._iuBikeRepository = IuBikeRepository;
            this.Mapper = mapper;

        }
        public List<YouBikeStationsDto> GetStations()
        {
            var DataResult=this._iuBikeRepository.GetStations();
            var result=this.Mapper.Map<List<YouBikeStationModel>, List<YouBikeStationsDto>>(DataResult);
            return result;


        }
    }
}
