using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YN_Network.Areas.Questions.Models;
using YN_Network.Data;

namespace YN_Network.Areas.Questions.Services
{
    public class QuestionService : IQuestionService
    {
        private ApplicationDbContext _dbContext { get; set; }

        public QuestionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<Question> GetMostPopularQuestions()
        {
            return _dbContext.Questions.OrderByDescending(x=>x.Views).ToList();
        }

        public ICollection<Question> GetQuestions()
        {
            return _dbContext.Questions.ToList();
        }
    }
}
