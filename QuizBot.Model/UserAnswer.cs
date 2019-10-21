using System;

namespace QuizBot.Model
{
    public class UserAnswer
    {
        public int QuestionId { get; set; }

        public int AnswerId { get; set; }

        public TimeSpan? Span
        {
            get
            {
                if (Start.HasValue && Stop.HasValue)
                {
                    return Stop.Value.Subtract(Start.Value);
                }

                return null;
            }
        }

        public DateTime? Start { get; set; }
        public DateTime? Stop { get; set; }
        public string Answer { get; set; }
    }
}