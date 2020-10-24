using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportAppNet.Entity
{
    public partial class UserMainTypSport
    {
        public int? UserId { get; set; }
        public int? MainTypSportId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual MainTypSportEntity User { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserEntity UserNavigation { get; set; }
    }
}
