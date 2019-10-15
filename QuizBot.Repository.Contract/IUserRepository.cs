using System;
using QuizBot.Model;

namespace QuizBot.Repository.Contract
{
    public interface IUserRepository
    {

        User GetUserById(int id);

        bool SaveUser(User user);
    }
}