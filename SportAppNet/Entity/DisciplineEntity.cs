using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportAppNet.Entity
{
    public partial class DisciplineEntity
    {
        public DisciplineEntity()
        {
            LocationEntity = new HashSet<LocationEntity>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string DisciplineName { get; set; }
        public int? MainTypSportId { get; set; }

        [ForeignKey(nameof(MainTypSportId))]
        [InverseProperty(nameof(MainTypSportEntity.DisciplineEntity))]
        public virtual MainTypSportEntity MainTypSport { get; set; }
        [InverseProperty("Discipline")]
        public virtual ICollection<LocationEntity> LocationEntity { get; set; }
    }
}
