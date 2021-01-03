using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.DTO
{
    public class OpinionPostDto
    {
    
        public Guid GuidUserId { get; set; }
        public string GeneralComment { get; set; }
        public int Punctuality { get; set; }
        public int Skill { get; set; }
    }
}
