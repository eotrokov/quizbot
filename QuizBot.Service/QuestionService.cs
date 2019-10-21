using System.Collections;
using System.Collections.Generic;
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

        public Question GetQuestion(IList<int> q)
        {
            return _questionRepository.GetQuestion(q);
        }
    }
}