using System.Collections;
using System.Collections.Generic;
using QuizBot.Model;

namespace QuizBot.Service.Contract
{
    public interface IQuestionService
    {
        Question GetQuestion(IList<int> q);
    }
}