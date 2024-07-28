using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public abstract class Exam 
    {
        public int ExamTime { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }

        public Exam(int examTime, int numberOfQuestions)
        {
            ExamTime = examTime;
            NumberOfQuestions = numberOfQuestions;
        }


        public abstract void alllist();


        public abstract void ShowExam();

        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}

        //public int CompareTo(Exam other)
        //{
        //    return this.NumberOfQuestions.CompareTo(other.NumberOfQuestions);
        //}

        public override string ToString()
        {
            return $"Exam Time: {ExamTime}\nNumber of Questions: {NumberOfQuestions}";
        }
    }

    public class FinalExam : Exam
    {
        public FinalExam(int Time, int numofQUESTION) : base(Time, numofQUESTION)
        {

        }
        public override void alllist()
        {

            Questions = new Question[NumberOfQuestions];
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                int choice;
                Console.WriteLine("Choose 1 For MCQQuestion , 2 For TrueFalseQuestion ");
                if (int.TryParse(Console.ReadLine() , out choice) && choice < 1 || choice > 2)
                {
                    Console.WriteLine("Enter type");
                }

                if(choice == 1)
                {
                    Questions[i] = new MCQQuestion();
                    Questions[i].AddToQuestions();
                }
                else
                {
                    Questions[i] = new TrueFalseQuestion();
                    Questions[i].AddToQuestions();
                }
            }
        }

        public override void ShowExam()
        {
            foreach (var Question in Questions)
            {
                Console.WriteLine(Question);

                for(int i = 0; i < Question.AnswerList.Length; i++)
                {
                    Console.WriteLine($" {Question.AnswerList[i]}");
                }
                Console.WriteLine("====================");

                int user;
                if (int.TryParse(Console.ReadLine(), out user) && user < 1 || user > 3)
                {
                    Console.WriteLine("Enter your answer");
                }
                Question.UserAnswer.AnswerId = user;
                Question.UserAnswer.AnswerText = Question.AnswerList[user - 1].AnswerText;
            }


            int TotalMarks = 0, Grade = 0;

            for (int i = 0; i < Questions.Length; i++)
            {
                TotalMarks += Questions[i].Mark;
                if (Questions[i].RightAnswer.AnswerId == Questions[i].UserAnswer.AnswerId)
                {
                    Grade += Questions[i].Mark;
                }
                Console.WriteLine($"Questions {i + 1} :: {Questions[i].Body}");
                Console.WriteLine($"Your Answer: {Questions[i].UserAnswer.AnswerText}");
            }
            Console.WriteLine($"your Grade :: {Grade} from {TotalMarks}");
        }
    }

    public class PracticalExam : Exam
    {
        public PracticalExam(int Time, int numofQUESTION) : base(Time, numofQUESTION)
        {
            Console.Write("hello");
        }

        public override void alllist()
        {
            Questions = new MCQQuestion[NumberOfQuestions];
            for(int i = 0;i < NumberOfQuestions;i++)
            {
                Questions[i] = new MCQQuestion();
                Questions[i].AddToQuestions();
            }
        }

        public override void ShowExam()
        {
            foreach (var Question in Questions)
            {
                Console.WriteLine(Question);

                for (int i = 0; i < Question.AnswerList.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Question.AnswerList[i]}");
                }
                Console.WriteLine("=========");

                int user;
                if (int.TryParse(Console.ReadLine(), out user) && user < 1 || user > 3)
                {
                    Console.WriteLine("Enter your answer");
                }
                Question.UserAnswer.AnswerId = user;
                Question.UserAnswer.AnswerText = Question.AnswerList[user - 1].AnswerText;
            }
            Console.Clear();

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Questions {i + 1} :: {Questions[i].Body}");
                Console.WriteLine($"Your Answer: {Questions[i].UserAnswer.AnswerText}");
            }
        }
    }

}
