using SportAppNet.DTO;
using SportAppNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Repository
{
   public interface ISportTypeRepository<T> where T : MainTypSportEntity
    {   
        Task<IEnumerable<T>> GetAllTypSport();
        Task<IEnumerable<T>> GetDisciplineByMainTypSport();
    }
}
