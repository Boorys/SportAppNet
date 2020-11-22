using SportAppNet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Service.IService
{
   public interface IDisciplineService
    {
       IEnumerable<DisciplineGetDto> GetAllDisciplineByMainTypSport(int mainTypSportId);
    }
}
