using System;
using QuizBot.Model;

namespace QuizBot.Repository.Contract
{
    public interface IQuestionRepository
    {
        Question GetQuestion();

    }
}