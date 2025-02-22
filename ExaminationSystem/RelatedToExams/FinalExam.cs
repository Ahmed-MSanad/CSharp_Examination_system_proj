using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.RelatedToQuestions;

namespace ExaminationSystem.RelatedToExams
{
    public class FinalExam : Exam
    {
        public override void showExam()
        {
            int StudentGrade = 0, TotalMark = 0;
            short userAnswer;

            for (int i = 0; i < QuestionsCount; i++)
            {
                Console.WriteLine($"{QuestionsList[i]}"); // --> using ToString to overwrite the Question

                TotalMark += QuestionsList[i].Mark;

                for (int j = 0; j < QuestionsList[i].AnswerList.Length; j++)
                {
                    Console.WriteLine($"{j + 1}.\t{QuestionsList[i].AnswerList[j]}");
                }

                Console.WriteLine(new string('-', 100));

                // ---------------------------------------------------- Validate user answer ----------------------------------------------------
                Console.Write("Your answer is: ");

                if (QuestionsList[i].QType == QTypeEnum.MCQ)
                {
                    while (!short.TryParse(Console.ReadLine(), out userAnswer) || userAnswer > 3 || userAnswer < 1)
                        Console.Write("Invalid Answer !! Please insert a number from 1 to 3 according to your answer.\nYour answer is: ");

                    QuestionsList[i].UserAnswer = QuestionsList[i].AnswerList[userAnswer - 1];
                }
                else if (QuestionsList[i].QType == QTypeEnum.TrueAndFalse)
                {
                    while (!short.TryParse(Console.ReadLine(), out userAnswer) || userAnswer > 2 || userAnswer < 1)
                        Console.Write("Invalid Answer !! Please insert a number from 1 to 2 according to your answer.\nYour answer is: ");

                    QuestionsList[i].UserAnswer = QuestionsList[i].AnswerList[userAnswer - 1];
                }


                // ---------------------------------------------------- Calculate user answer ----------------------------------------------------
                StudentGrade += (QuestionsList[i].RightAnswer == QuestionsList[i].UserAnswer ? QuestionsList[i].Mark : 0);

                Console.WriteLine($"{new string('=', 100)}\n");
            }

            Console.Clear();

            Console.WriteLine("Your Answers: ");
            for (int i = 0; i < QuestionsCount; i++)
            {
                Console.WriteLine($"Q{i + 1})\t\t {QuestionsList[i]?.QuestionBody}: {QuestionsList[i]?.UserAnswer}");
            }
            Console.WriteLine($"Your Exam Grad is {StudentGrade} from {TotalMark}");
        }

        public override void CreateExamQuestions()
        {
            for (int i = 0; i < QuestionsCount; i++)
            {
                Console.Write($"Please Choose The Type Of The Question Number({i})  (1 for True OR False || 2 for MCQ): ");
                short questionChoice;
                while (!short.TryParse(Console.ReadLine(), out questionChoice) || questionChoice > 2 || questionChoice < 1)
                    Console.Write("Invalid Question Number !! Please insert a number from 1 to 2.\n(1 for True OR False || 2 for MCQ): ");

                Console.Clear();

                if (questionChoice == 1)
                {
                    TFQuestion TFQ = new TFQuestion();
                    TFQ.CreateQuestion();
                    QuestionsList[i] = TFQ;
                }
                else if (questionChoice == 2)
                {
                    SingleChoiceQuestion MCQ = new SingleChoiceQuestion();
                    MCQ.CreateQuestion();
                    QuestionsList[i] = MCQ;
                }
            }
        }
    }
}
