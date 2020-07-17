using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YN_Network.Models;

namespace YN_Network.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Areas.Questions.Models.Question> Questions { get; set; }
        public DbSet<Areas.Questions.Models.Answer> Answers { get; set; }

        public DbSet<Areas.News.Models.Source> NewsSources { get; set; }
    }
}
