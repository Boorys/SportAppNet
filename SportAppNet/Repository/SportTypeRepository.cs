using Microsoft.EntityFrameworkCore;
using SportAppNet.DTO;
using SportAppNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Repository
{
    public class SportTypeRepository<T> : ISportTypeRepository<T> where T : MainTypSportEntity
    {
        public async Task<IEnumerable<T>> GetAllTypSport()
        {
            using (var context = new Context())
            {
                var mainTypSportEntityList = context.MainTypSportEntity;
              
                return await context.Set<T>().ToListAsync();
            }
        }
   
  

    }
}
