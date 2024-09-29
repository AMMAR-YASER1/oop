using System;
using System.Collections.Generic;

class Question
{
    public string Text { get; private set; }
    public string Answer { get; private set; }

    public Question(string text, string answer)
    {
        Text = text;
        Answer = answer;
    }

    public bool CheckAnswer(string userAnswer)
    {
        return string.Equals(userAnswer, Answer, StringComparison.OrdinalIgnoreCase);
    }
}

class Quiz
{
    private List<Question> questions;
    private int score;

    public Quiz()
    {
        questions = new List<Question>();
        score = 0;
    }

    public void AddQuestion(Question question)
    {
        questions.Add(question);
    }

    public void Start()
    {
        foreach (var question in questions)
        {
            Console.WriteLine(question.Text);
            string userAnswer = Console.ReadLine();

            if (question.CheckAnswer(userAnswer))
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer is: {question.Answer}");
            }
        }

        Console.WriteLine($"Your final score is: {score}/{questions.Count}");
    }
}

class QuizApp
{
    static void Main(string[] args)
    {
        Quiz quiz = new Quiz();

        // Sample questions
        quiz.AddQuestion(new Question("What is the capital of France?", "Paris"));
        quiz.AddQuestion(new Question("What is 2 + 2?", "4"));
        quiz.AddQuestion(new Question("What is the color of the sky?", "Blue"));

        quiz.Start();
    }
}
