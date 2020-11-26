using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAppNet.Tool;

namespace SportAppNet.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {

        [HttpPost]
        public IActionResult AddNotice()
        {
            return Ok();
        }

        [Route("test")]
        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }

    }
}
