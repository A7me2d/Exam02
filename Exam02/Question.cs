using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public abstract class Question
    {
        public string Header { get; protected set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer UserAnswer { get; }

        public Question()
        {
            RightAnswer = new Answer();
            UserAnswer = new Answer();
        }

        public abstract void AddToQuestions();

        public override string ToString()
        {
            return $"{Header}\n{Body}\nMark: {Mark}";
        }
    }

    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion()
        {
            Header = "You are in the True or False section";
            Body = "Enter your Question Please:";
            AnswerList = new Answer[2];
            AnswerList[0] = new Answer { AnswerId = 1, AnswerText = "true" };
            AnswerList[1] = new Answer { AnswerId = 2, AnswerText = "false" };
        }

        public override void AddToQuestions()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            Body = Console.ReadLine();
            //Console.WriteLine("=========Your Question is=========");
            //Console.WriteLine($"{Body}");
            //Console.WriteLine("Choose T or F");

            //foreach (var answer in AnswerList)
            //{
            //    Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
            //}

            Console.Write("Enter The Marks ");
            if (int.TryParse(Console.ReadLine(), out int mark))
            {
                Console.WriteLine("Seccses");
            }
            else
            {
                Console.WriteLine("Invalid mark input. Mark set to 0.");
                mark = 0;
            }
            Mark = mark;

            //Console.Write("Enter your answer (True/False): ");
            //UserAnswer.AnswerText = Console.ReadLine();
            //Console.WriteLine($"Your Answer: {UserAnswer.AnswerText}");
            //Console.Write("Enter the correct answer (True/False): ");
            //RightAnswer.AnswerText = Console.ReadLine();

            //Console.WriteLine($"{UserAnswer.AnswerText} , {RightAnswer.AnswerText}");
            //Console.Write("Enter the mark for this question: ");


            //Console.WriteLine($"Mark: {Mark}");


            Console.WriteLine("Please Enter The Right Answer of Question (1 for True and 2 for False):");
            if (!int.TryParse(Console.ReadLine(), out int RightAnswerId) && RightAnswerId < 1 || RightAnswerId > 2)
            {
                Console.WriteLine("Added Seccer Answer!");
            }
            
            RightAnswer.AnswerId = RightAnswerId;
            RightAnswer.AnswerText = AnswerList[RightAnswerId - 1].AnswerText;
            Console.Clear();
        }
    

    public class MCQQuestion : Question
    {
        public MCQQuestion()
        {
            Header = "You choose the MCQ Exam";
            Body = "Enter your Question Please:";
            AnswerList = new Answer[3];
        }

        public override void AddToQuestions()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            Body = Console.ReadLine();


            int mark;
            Console.Write("Enter the mark for this question: ");
            if (int.TryParse(Console.ReadLine(), out mark))
            {
                Mark = mark;
            }
            else
            {
                Console.WriteLine("Invalid mark input. Mark set to 0.");
                mark = 0;
            }

            Console.WriteLine("=========Your Question MCQ is=========");
            Console.WriteLine("Enter MCQ Answers");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter Answer Number {i + 1}:");
                AnswerList[i] = new Answer
                {
                    AnswerId = i + 1
                };
                AnswerList[i].AnswerText = Console.ReadLine();
            }


            Console.Write("Enter the ID of the correct answer (1, 2, or 3): ");
            if (!int.TryParse(Console.ReadLine(), out int correct) && correct >= 1 && correct <= 3)
            {
                Console.Write("Enter the ID of the correct answer (1, 2, or 3): ");
            }
            else
            {
                Console.WriteLine("Invalid answer ID. No correct answer set.");
            }

            RightAnswer.AnswerId = correct;
            //1---3
            RightAnswer.AnswerText = AnswerList[correct - 1].AnswerText;
        }
    }
}