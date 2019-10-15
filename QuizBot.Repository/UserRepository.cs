using System;
using System.Collections;
using System.Collections.Generic;
using QuizBot.Model;
using QuizBot.Repository.Contract;
using System.Linq;

namespace QuizBot.Repository
{
    public class UserRepository : IUserRepository
    {
        private IEnumerable<User> _users;

        public UserRepository()
        {
            _users = Enumerable.Empty<User>();
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveUser(User user)
        {
            _users = _users.Append<User>(user);
            return true;
        }
    }
}