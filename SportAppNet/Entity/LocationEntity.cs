using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportAppNet.Entity
{
    public partial class LocationEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Department { get; set; }
        [Column(TypeName = "decimal(10, 10)")]
        public decimal Lang { get; set; }
        [Column(TypeName = "decimal(10, 10)")]
        public decimal Lat { get; set; }
        public int LocationId { get; set; }
        [Required]
        public string Street { get; set; }
        public int StreetNumber { get; set; }
    }
}
