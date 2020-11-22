using AutoMapper;
using SportAppNet.DTO;
using SportAppNet.Entity;
using SportAppNet.Repository;
using SportAppNet.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Service.Service
{
    public class SportTypeService : ISportTypeService
    {

        private readonly ISportTypeRepository<MainTypSportEntity> _sportTypeRepository;
        private readonly IMapper _mapper;
        public SportTypeService(ISportTypeRepository<MainTypSportEntity> sportTypeRepository, IMapper mapper)
        {
            _sportTypeRepository = sportTypeRepository;
            _mapper = mapper;
        }

        public List<MainTypSportGetDto> GetAllSportTypeService()
        {     
            return _mapper.Map(_sportTypeRepository.GetAllTypSport().Result.ToList(),new List<MainTypSportGetDto>());
        }

    }
}
