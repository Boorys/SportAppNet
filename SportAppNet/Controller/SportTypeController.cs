using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAppNet.Entity;
using SportAppNet.Repository;
using SportAppNet.Service.IService;

namespace SportAppNet.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class SportTypeController : ControllerBase
    {

        private readonly ISportTypeService _sportTypeService;
        private readonly IDisciplineService _disciplineService;

        public SportTypeController(ISportTypeService sportTypeService, IDisciplineService disciplineService)
        {         
            _sportTypeService = sportTypeService;
            _disciplineService = disciplineService;
        }

        [HttpGet]
        [Route("mainTypSport")]
        public IActionResult GetAllMainTypSport()
        {
            return Ok(_sportTypeService.GetAllSportTypeService());
        }

        [HttpGet]
        [Route("discipline/{mainSportId}")]
        public IActionResult GetDisciplineByMainTypSport(int mainSportId)
        {
            return Ok(_disciplineService.GetAllDisciplineByMainTypSport(mainSportId));
        }

    }
}
