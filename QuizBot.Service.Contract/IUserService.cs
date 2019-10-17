using System;
using QuizBot.Model;

namespace QuizBot.Service.Contract
{
    public interface IUserService
    {
        User GetUserById(int fromId);
        bool SaveUser(User user);
    }
}