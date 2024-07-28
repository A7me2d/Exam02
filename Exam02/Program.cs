using System.Diagnostics;

namespace Exam02
{
    internal class Program
    {
        static void Main(string[] args)
        {

       
            Console.WriteLine("Enter 'Y' or 'y' TO start the Exam. and 'N' or 'n' to End");
            char choice = char.Parse(Console.ReadLine());
            if (choice == 'y' || choice == 'Y')
            {
                Subject subject = new Subject(1, "C#");
                subject.CreateExam();
                Stopwatch sw = new();
                sw.Start();
                subject.SubjectExam.ShowExam();
                Console.WriteLine("the time ", sw.Elapsed);
            }
            else
                Console.WriteLine("You Choiase 'N' to End the Exam");

        }
    }
}
