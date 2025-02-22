using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.RelatedToAnswers;

namespace ExaminationSystem.RelatedToQuestions
{
    public class TFQuestion : Question
    {
        public TFQuestion() : base(2, 1, "True | False Question")
        {
            AnswerList[0] = new Answer();
            AnswerList[1] = new Answer();

            AnswerList[0].AnswerId = 1;
            AnswerList[0].AnswerText = "True";

            AnswerList[1].AnswerId = 2;
            AnswerList[1].AnswerText = "False";

            QType = QTypeEnum.TrueAndFalse;
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


            int rightChoice;
            Console.WriteLine("Please Enter The Right Answer Of the Question (1 for True and 2 for False): ");
            while (!int.TryParse(Console.ReadLine(), out rightChoice) || rightChoice > 2 || rightChoice < 1)
                Console.Write("Invalid Answer !! Please insert a number from 1 to 2 according to the right answer.\nYour right answer is: ");

            RightAnswer.AnswerId = rightChoice;
            if (RightAnswer.AnswerId == 1)
                RightAnswer.AnswerText = "True";
            else if (RightAnswer.AnswerId == 2)
                RightAnswer.AnswerText = "False";

            Console.Clear();
        }
    }
}
