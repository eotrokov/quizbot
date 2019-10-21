using System.Collections.Generic;
using System.Linq;
using QuizBot.Model;
using QuizBot.Repository.Contract;

namespace QuizBot.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private IEnumerable<Question> _questions;

        public QuestionRepository()
        {
            _questions = new List<Question>()
            {
                Question.Create(),
                Question.Create(),
                Question.Create(),
                Question.Create(),
                Question.Create(),
                Question.Create(),
                Question.Create(),
                Question.Create()
            };
        }

        public Question GetQuestion(IList<int> q)
        {
            return _questions.FirstOrDefault(c => !q.Contains(c.Id));
        }
    }
}