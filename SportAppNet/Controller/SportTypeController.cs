using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAppNet.Entity;
using SportAppNet.Repository;

namespace SportAppNet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportTypeController : ControllerBase
    {

        private readonly ISportTypeRepository<MainTypSportEntity> _sportRepository;
        private readonly IDisciplineRepository<DisciplineEntity> _disciplineRepository;

        public SportTypeController(ISportTypeRepository<MainTypSportEntity> sportRepository,IDisciplineRepository<DisciplineEntity> disciplineRepository)
        {
            _sportRepository = sportRepository;
            _disciplineRepository = disciplineRepository;
        }


        public IActionResult GetAllMainTypSports()
        {
            return Ok(_sportRepository.GetAllTypSport());
        }

        [HttpGet]
        [Route("discipline/{mainSportId}")]
        public IActionResult GetDisciplineByMainTypSport(int mainSportId)
        {
            return Ok(_disciplineRepository.GetAllDisciplineByMainTypSport(mainSportId).ToList());
        }

    }
}
