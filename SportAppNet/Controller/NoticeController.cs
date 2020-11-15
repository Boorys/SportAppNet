using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportAppNet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
 
    [HttpPost]
    public IActionResult AddNotice()
    {
       return Ok();
    }        
    }
}
