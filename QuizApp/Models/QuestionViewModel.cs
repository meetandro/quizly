using QuizApp.Entities;

namespace QuizApp.Models;

public class QuestionViewModel
{
    public Question? Question { get; set; }
    public int CorrectAnswerIndex { get; set; }
}