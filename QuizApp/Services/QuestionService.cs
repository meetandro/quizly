using QuizApp.Models;

namespace QuizApp.Services;

public class QuestionService : IQuestionService
{
    private static List<Question> _questions = new();

    public List<Question> GetQuestions()
    {
        return _questions;
    }

    public void AddQuestion(Question question, int correctAnswerIndex)
    {
        question.Id = _questions.Count + 1;
        question.Answers[correctAnswerIndex].IsCorrect = true;
        _questions.Add(question);
    }

    public void DeleteQuestion(int id)
    {
        _questions.RemoveAll(q => q.Id == id);
    }
}