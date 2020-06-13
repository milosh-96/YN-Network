using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YN_Network.Areas.Questions.Models;
using YN_Network.Areas.Questions.Services;

namespace YN_Network.Areas.Questions.ViewModels
{
    public class QuestionsHomeViewModel
    {
        public ICollection<Question> MostPopularQuestions { get; set; }
        public ICollection<Question> Questions { get; set; }


    }
}
