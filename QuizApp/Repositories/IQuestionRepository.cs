using QuizApp.Models;

namespace QuizApp.Repositories;

public interface IQuestionRepository
{
    public List<Question> GetQuestions();
    public Question GetQuestionById(int id);
    public List<Answer> GetAnswersByIds(List<int> ids);
    public Question AddQuestion(Question question, int correctAnswerIndex);
    public Question DeleteQuestion(int id);
}