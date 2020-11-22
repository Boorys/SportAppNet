using Microsoft.EntityFrameworkCore;
using SportAppNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Repository
{
    public class DisciplineRepository<T> : IDisciplineRepository<T> where T : DisciplineEntity
    {
   
    
      public async Task<IEnumerable<T>> GetAllDisciplineByMainTypSport(int mainTypSportId)
        {
            using (var context = new Context())
            {            
                return await context.Set<T>().Include(x=>x.MainTypSport).Where(x=>x.MainTypSport.Id == mainTypSportId).ToListAsync();
            }
        }
    }
}
