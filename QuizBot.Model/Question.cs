using System.Collections.Generic;

namespace QuizBot.Model
{
    public class Question
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}