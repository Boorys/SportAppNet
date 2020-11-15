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
   
        public IQueryable<MainTypSportEntity> GetAllDisciplineByMainTypSport(int mainTypSportId)
        {
            using(var context = new Context())
            {          
                return context.MainTypSportEntity.Include(x=>x.DisciplineEntity).Where(x=>x.Id==mainTypSportId);
            }
        }
    }
}
