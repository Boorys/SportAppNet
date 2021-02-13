using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.DTO
{
    public class LocationPostDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int DisciplineEntityId { get; set; }
    }
}
