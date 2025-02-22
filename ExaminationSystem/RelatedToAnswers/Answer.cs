using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.RelatedToAnswers
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }

        public static bool operator ==(Answer ans1, Answer ans2)
        {
            return ans1.AnswerText.Equals(ans2.AnswerText) && ans1.AnswerId == ans2.AnswerId;
        }

        public static bool operator !=(Answer ans1, Answer ans2)
        {
            return !(ans1.AnswerText.Equals(ans2.AnswerText) && ans1.AnswerId == ans2.AnswerId);
        }

        public override string ToString()
        {
            return $"{AnswerText}";
        }
    }
}
