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
                return await context.Set<T>().ToListAsync();
            }
        }

        public Task<IEnumerable<T>> GetDisciplineByMainTypSport()
        {
            throw new NotImplementedException();
        }
    }
}
