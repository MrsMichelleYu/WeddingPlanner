using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column("FirstName", TypeName = "VARCHAR(45)")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName", TypeName = "VARCHAR(45)")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email", TypeName = "VARCHAR(45)")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        [Column("Password", TypeName = "VARCHAR(255)")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Wedding> CreatedWeddings { get; set; }
        public List<JoinedWedding> JoinedWeddings { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}