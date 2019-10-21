using System;
using System.Collections.Generic;

namespace QuizBot.Model
{
    public class Question
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        private static Random r = new Random();
        public static Question Create()
        {
            return new Question
            {
                Id = r.Next(0,999),
                Title =  "rfr"+ r.Next(0,999),
                Answers = new List<Answer>
                {
                    new Answer{ Id = 1, Title = "dd", IsCorrect = true},
                    new Answer{ Id = 2, Title = "qq"},
                    new Answer{ Id = 3, Title = "ww"},
                    new Answer{ Id = 4, Title = "ee"}
                }
            };
        }
    }
}