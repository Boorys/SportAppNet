using SportAppNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Repository
{
    public interface IDisciplineRepository<T> where T : DisciplineEntity
    {

        public Task<IEnumerable<T>> GetAllDisciplineByMainTypSport(int mainTypSportId);


    }
}
