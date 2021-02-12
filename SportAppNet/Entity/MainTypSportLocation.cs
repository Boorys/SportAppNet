using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportAppNet.Entity
{
    public partial class MainTypSportLocation
    {
        public int LocationId { get; set; }
        public int MainTypSportId { get; set; }

        [ForeignKey(nameof(LocationId))]
        public virtual LocationEntity Location { get; set; }
        [ForeignKey(nameof(MainTypSportId))]
        public virtual MainTypSportEntity MainTypSport { get; set; }
    }
}
