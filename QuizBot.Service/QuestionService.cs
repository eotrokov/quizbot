using QuizBot.Model;
using QuizBot.Repository.Contract;
using QuizBot.Service.Contract;

namespace QuizBot.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public Question GetQuestion()
        {
            return _questionRepository.GetQuestion();
        }
    }
}