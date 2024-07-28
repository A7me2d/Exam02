using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

  public void CreateExam()
{
    int examType, time, numberOfQuestions;


    examType = GetExamType();


    time = GetExamTime();


    numberOfQuestions = GetNumberOfQuestions();


    if (examType == 1)
    {
        SubjectExam = new PracticalExam(time, numberOfQuestions);
    }
    else
    {
        SubjectExam = new FinalExam(time, numberOfQuestions);
    }

    //Console.Clear();


    SubjectExam.alllist();
}

private int GetExamType()
{
    while (true)
    {
        Console.Write("Please choose the type of the Exam [1 for Practise, 2 for Final Exam]: ");
        string input = Console.ReadLine();

        if (input == "1" || input == "2")
        {
            return int.Parse(input);
        }

        Console.WriteLine("Invalid input. Please enter 1 for Practical or 2 for Final.");
    }
}

private int GetExamTime()
{
    while (true)
    {
        Console.Write("Please enter the time of the Exam in minutes (From 30 Min To 180 Min): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int time) && time >= 30 && time <= 180)
        {
            return time;
        }

        Console.WriteLine("Invalid input. Please enter a time between 30 and 180 minutes.");
    }
}

private int GetNumberOfQuestions()
{
    while (true)
    {
        Console.Write("Please enter the number of questions: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int numberOfQuestions))
        {
                    Console.WriteLine($"questions Number {numberOfQuestions}");
                    return numberOfQuestions;
        }

        Console.WriteLine("Invalid input. Please enter a valid number of questions.");
    }
}

        public override string ToString()
        {
            return $"Subject Id: {SubjectId}\nSubject Name: {SubjectName}\n{SubjectExam}";
        }
    }

}
