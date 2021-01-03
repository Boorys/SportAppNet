using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportAppNet.DTO;
using SportAppNet.Service.IService;
using SportAppNet.Service.Service;

namespace SportAppNet.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {

        private readonly IOpinionService _opinionService;

        public OpinionController(IOpinionService opinionService)
        {
            _opinionService = opinionService;
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(OpinionPostDto opinionPostDto)
        {
            _opinionService.AddOpinion(opinionPostDto);
            int w = 7;
            return Ok();
        }




    }
}
