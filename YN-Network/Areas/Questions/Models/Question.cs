using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Slugify;

namespace YN_Network.Areas.Questions.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public IdentityUser<Guid> User { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Title { get; set; }

        public string Description { get; set; }
        public int Views { get; set; }
        public List<Answer> Answers { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string OptionA { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string OptionB { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }


        [NotMapped]
        private string slug = "";

        [NotMapped]
        public string Slug
        {
            get { return (new SlugHelper()).GenerateSlug(this.Title).ToString(); }
            set { slug = value; }
        }
    }

    public class Answer
    {
        public Guid Id { get; set; }
        public IdentityUser<Guid> User { get; set; }


        [Column(TypeName = "bool")]
        public bool OptionA { get; set; }

        [Column(TypeName = "bool")]
        public bool OptionB { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Explanation { get; set; }

        public Question Question { get; set; }
    }
}
