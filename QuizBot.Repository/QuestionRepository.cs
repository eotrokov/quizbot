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
                new Question
                {
                    Id = 1,
                    Title = "***как***",
                    Answers = new List<Answer>()
                    {
                        new Answer
                        {
                            Id = 1, Title = "1"
                        },
                        new Answer
                        {
                            Id = 2, Title = "2"
                        },
                        new Answer
                        {
                            Id = 3, Title = "3", IsCorrect = true
                        },
                        new Answer
                        {
                            Id = 4, Title = "4"
                        }
                    }
                }
            };
        }

        public Question GetQuestion()
        {
            return _questions.First();
        }
    }
}