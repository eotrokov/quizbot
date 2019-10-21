using System;
using System.Collections.Generic;
using QuizBot.Model;

namespace QuizBot.Repository.Contract
{
    public interface IQuestionRepository
    {
        Question GetQuestion(IList<int> q);

    }
}