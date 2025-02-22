using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.RelatedToQuestions;

namespace ExaminationSystem.RelatedToExams
{
    public abstract class Exam
    {
        public TimeOnly ExamTime { get; set; }
        public int QuestionsCount { get; set; }

        public Question[]? QuestionsList { get; set; }

        public abstract void CreateExamQuestions();

        public abstract void showExam();
    }
}
