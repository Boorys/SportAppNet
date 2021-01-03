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
    public class DisciplineService : IDisciplineService
    {
        private readonly IDisciplineRepository<DisciplineEntity> _disciplineRepository;
        private readonly IMapper _mapper;
        public DisciplineService(IDisciplineRepository<DisciplineEntity> disciplineRepository, IMapper mapper)
        {
            _disciplineRepository = disciplineRepository;
            _mapper = mapper;
        }

        public IEnumerable<DisciplineGetDto> GetAllDisciplineByMainTypSport(int mainTypSportId)
        {
            var disciplineEntityList = _disciplineRepository.GetAllDisciplineByMainTypSport(mainTypSportId).Result;
            return _mapper.Map(disciplineEntityList, new List<DisciplineGetDto>());
        }
    }
}
