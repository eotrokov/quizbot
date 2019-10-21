using System;

namespace QuizBot.Model
{
    public class UserAnswer
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public TimeSpan Span => Stop.Value.Subtract(Start.Value);
        public DateTime? Start { get; set; }
        public DateTime? Stop { get; set; }
    }
}