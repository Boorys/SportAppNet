using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportAppNet.Entity
{
    public partial class UserEntity
    {
        public UserEntity()
        {
            OpinionEntity = new HashSet<OpinionEntity>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Column("role")]
        [StringLength(50)]
        public string Role { get; set; }
        [Required]
        [StringLength(64)]
        public string Password { get; set; }
        public bool? IsActive { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<OpinionEntity> OpinionEntity { get; set; }
    }
}
