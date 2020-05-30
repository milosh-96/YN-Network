using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace YN_Network.Areas.Questions.Models
{
    public class Question
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public List<Answer> Answers { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset DeletedAt { get; set; }
    }

    public class Answer
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public bool OptionA { get; set; }
        public bool OptionB { get; set; }
        public string Explanation { get; set; }

        public Question Question { get; set; }
    }
}
