using QuizApp.Models;

namespace QuizApp.Services;

public interface IQuestionService
{
    public List<Question> GetQuestions();
    public void AddQuestion(Question question, int correctAnswerIndex);
    public void DeleteQuestion(int id);
}