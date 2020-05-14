using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YN_Network.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "text")]
        public User User { get; set; }

        public DateTime CreatedAt { get; set; }
        
    }
}
