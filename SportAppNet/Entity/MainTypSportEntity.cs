using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportAppNet.Entity
{
    public partial class MainTypSportEntity
    {
        public MainTypSportEntity()
        {
            DisciplineEntity = new HashSet<DisciplineEntity>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string MainNameOfSport { get; set; }

        [InverseProperty("MainTypSport")]
        public virtual ICollection<DisciplineEntity> DisciplineEntity { get; set; }
    }
}
