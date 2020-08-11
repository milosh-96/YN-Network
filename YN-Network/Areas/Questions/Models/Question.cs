using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Slugify;

namespace YN_Network.Areas.Questions.Models
{
    public class Question
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }

        [Column(TypeName = "string")]
        public string Title { get; set; }

        public string Description { get; set; }
        public int Views { get; set; }
        public List<Answer> Answers { get; set; }

        [Column(TypeName = "string")]
        public string OptionA { get; set; }

        [Column(TypeName = "string")]
        public string OptionB { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime UpdatedAt { get; set; }

        [Column(TypeName = "DateTime")]
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
        public int Id { get; set; }
        public IdentityUser User { get; set; }

        [Column(TypeName = "bool")]
        public bool OptionA { get; set; }

        [Column(TypeName = "bool")]
        public bool OptionB { get; set; }

        public string Explanation { get; set; }

        public Question Question { get; set; }
    }
}
