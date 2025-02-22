using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.RelatedToAnswers;

namespace ExaminationSystem.RelatedToQuestions
{
    public class SingleChoiceQuestion : Question
    {
        public SingleChoiceQuestion() : base(3, 1, "Choose One Answer Question")
        {
            AnswerList[0] = new Answer();
            AnswerList[1] = new Answer();
            AnswerList[2] = new Answer();

            QType = QTypeEnum.MCQ;
        }

        public override void CreateQuestion()
        {
            Console.WriteLine(QuestionHeader);

            Console.WriteLine("Please Enter The Body Of the Question: ");
            QuestionBody = Console.ReadLine();

            int Marks;
            Console.WriteLine("Please Enter The Marks Of the Question: ");
            while (!int.TryParse(Console.ReadLine(), out Marks) || Marks < 0)
                Console.Write("Invalid Number of Marks !! Please insert a Valid number of Marks: ");
            Mark = Marks;


            Console.WriteLine("The Choices of the Question: ");

            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Please Enter the Choice Number {j + 1}: ");
                AnswerList[j].AnswerId = j + 1;
                AnswerList[j].AnswerText = Console.ReadLine();
            }


            int rightChoice;
            Console.WriteLine("Please Specify the Right Choice Of the Question: ");
            while (!int.TryParse(Console.ReadLine(), out rightChoice) || rightChoice > 3 || rightChoice < 1)
                Console.Write("Invalid Answer !! Please insert a number from 1 to 3 according to the right answer.\nYour right answer is: ");
            RightAnswer.AnswerId = rightChoice;
            RightAnswer.AnswerText = AnswerList?.Where(answer => answer?.AnswerId == rightChoice)?.FirstOrDefault()?.AnswerText;

            Console.Clear();
        }

    }
}
