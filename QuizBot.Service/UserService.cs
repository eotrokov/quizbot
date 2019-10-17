using System;
using QuizBot.Model;
using QuizBot.Repository.Contract;
using QuizBot.Service.Contract;

namespace QuizBot.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int fromId) => _userRepository.GetUserById(fromId);
        public bool SaveUser(User user) => _userRepository.SaveUser(user);
    }
}