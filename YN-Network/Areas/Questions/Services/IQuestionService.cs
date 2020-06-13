using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YN_Network.Areas.Questions.Models;
namespace YN_Network.Areas.Questions.Services
{
    public interface IQuestionService
    {
        public ICollection<Question> GetQuestions();
        public ICollection<Question> GetMostPopularQuestions();
    }
}
