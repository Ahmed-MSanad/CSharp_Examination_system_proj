using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.RelatedToExams;
using ExaminationSystem.RelatedToQuestions;

namespace ExaminationSystem.RelatedToSubjects
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public Exam? _Exam { get; set; }

        public Subject(int _SubjectId, string? _SubjectName)
        {
            SubjectId = _SubjectId;
            SubjectName = _SubjectName;
        }

        public void CreateExam()
        {
            Console.Write("Please Enter The Type of Exam You Want to Create(1 for Practical and 2 for Final): ");
            short ExamChoice;
            while (!short.TryParse(Console.ReadLine(), out ExamChoice) || ExamChoice > 2 || ExamChoice < 1)
                Console.Write("Invalid Exam Number !! Please insert a number from 1 to 2.\n(1 for Practical and 2 for Final): ");
            if (ExamChoice == 1)
                _Exam = new PracticalExam();
            else if (ExamChoice == 2)
                _Exam = new FinalExam();
            

            Console.Write("Please Enter the Time Of The Exam in Minutes: ");
            int minutes;
            while (!int.TryParse(Console.ReadLine(), out minutes) || minutes < 0)
                Console.Write("Invalid Exam Time !! Please insert a Valid Exam Duration in minutes: ");
            _Exam.ExamTime = new TimeOnly(minutes/60, minutes%60);
            

            Console.Write("Please Enter the Number Of Questions You Wanted To Create: ");
            int numberOfQuestions;
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions < 0)
                Console.Write("Invalid Number of Questions !! Please Enter Valid Number Of Questions You Wanted To Create: ");
            _Exam.QuestionsCount = numberOfQuestions;


            _Exam.QuestionsList = new Question[_Exam.QuestionsCount];


            Console.Clear();


            _Exam.CreateExamQuestions();
        }
    }
}
