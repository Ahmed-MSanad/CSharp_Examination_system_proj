using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.RelatedToAnswers;

namespace ExaminationSystem.RelatedToQuestions
{
    public abstract class Question
    {
        public string? QuestionHeader { get; set; }
        public string? QuestionBody { get; set; }
        public int Mark { get; set; }
        public Answer[]? AnswerList { get; set; }
        public Answer? RightAnswer { get; set; }
        public Answer? UserAnswer { get; set; }
        public QTypeEnum QType { get; set; }

        public Question(int answerCount, int rightAnswerCount, string? _QuestionHeader)
        {
            this.AnswerList = new Answer[answerCount];
            this.RightAnswer = new Answer();
            this.QuestionHeader = _QuestionHeader;
        }

        public abstract void CreateQuestion();

        public override string ToString()
        {
            return $"{QuestionHeader} \t Marks({Mark})\n{QuestionBody}";
        }

    }
}
