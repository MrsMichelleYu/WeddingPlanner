using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class JoinedWedding
    {
        [Key]
        public int JoinedWeddingId { get; set; }

        public int UserId { get; set; }

        public int WeddingId { get; set; }

        public User GuestInfo { get; set; }

        public Wedding WeddingInfo { get; set; }

    }

}