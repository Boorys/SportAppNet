using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportAppNet.Entity
{
    public partial class OpinionEntity
    {
        [Key]
        public int Id { get; set; }
        public string GeneralComment { get; set; }
        public int? Punctuality { get; set; }
        public int? Skill { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserEntity.OpinionEntity))]
        public virtual UserEntity User { get; set; }
    }
}
