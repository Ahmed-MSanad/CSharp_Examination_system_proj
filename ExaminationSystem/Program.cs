using System.Diagnostics;
using ExaminationSystem.RelatedToSubjects;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(10, "C#");

            subject.CreateExam();

            Console.Clear();

            Console.WriteLine("Do You Want to Start The Exam (y | n): ");

            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                subject?._Exam?.showExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }
            else
            {
                Console.WriteLine("Thank You.");
            }

        }
    }
}
