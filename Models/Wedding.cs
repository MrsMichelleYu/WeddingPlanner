using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required]
        [Column("BrideName", TypeName = "VARCHAR(45)")]
        public string BrideName { get; set; }

        [Required]
        [Column("GroomName", TypeName = "VARCHAR(45)")]
        public string GroomName { get; set; }

        [Required]
        [FutureDate]
        public DateTime Date { get; set; }

        [Required]
        public string Address { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public User Creator { get; set; }
        public List<JoinedWedding> Guests { get; set; }

    }
}