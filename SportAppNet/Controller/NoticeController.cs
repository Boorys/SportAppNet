using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAppNet.DTO;
using SportAppNet.Service.IService;
using SportAppNet.Tool;

namespace SportAppNet.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {

        private readonly INoticeService _InoticeService;

        public NoticeController(INoticeService noticeService)
        {
            _InoticeService = noticeService;
        }

        [HttpPost]
        public IActionResult AddNotice(NoticePostDto noticePostDto)
        {
            _InoticeService.AddNotice(noticePostDto);
                   
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
