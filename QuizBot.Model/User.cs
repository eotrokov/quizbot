using System;
using System.Collections.Generic;
using System.Data.Common;

namespace QuizBot.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}