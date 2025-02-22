using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.RelatedToQuestions;

namespace ExaminationSystem.RelatedToExams
{
    public class PracticalExam : Exam
    {
        public override void showExam()
        {
            short userAnswer;

            for (int i = 0; i < QuestionsCount; i++)
            {
                Console.WriteLine($"{QuestionsList[i]}"); // --> using ToString to overwrite the Question

                for (int j = 0; j < QuestionsList[i].AnswerList.Length; j++)
                {
                    Console.WriteLine($"{j + 1}.\t{QuestionsList[i].AnswerList[j]}");
                }

                Console.WriteLine(new string('-', 100));

                Console.Write("Your answer is: ");
                while (!short.TryParse(Console.ReadLine(), out userAnswer) || userAnswer > 3 || userAnswer < 1)
                    Console.Write("Invalid Answer !! Please insert a number from 1 to 3 according to your answer.\nYour answer is: ");

                QuestionsList[i].UserAnswer = QuestionsList[i].AnswerList[userAnswer - 1];

                Console.WriteLine($"{new string('=', 100)}\n");
            }

            Console.Clear();

            Console.WriteLine("Your Answers: ");
            for (int i = 0; i < QuestionsCount; i++)
            {
                Console.WriteLine($"Q{i + 1})\t\t {QuestionsList[i]?.QuestionBody}: {QuestionsList[i].UserAnswer}");

                if (QuestionsList[i].RightAnswer != QuestionsList[i].UserAnswer) // operator overloading to == and !=
                {
                    Console.WriteLine($"The Right answer should be: {QuestionsList[i].RightAnswer}");
                }
            }
        }

        public override void CreateExamQuestions()
        {
            for (int i = 0; i < QuestionsCount; i++)
            {
                SingleChoiceQuestion MCQ = new SingleChoiceQuestion();
                MCQ.CreateQuestion();
                QuestionsList[i] = MCQ;
            }
        }
    }
}
