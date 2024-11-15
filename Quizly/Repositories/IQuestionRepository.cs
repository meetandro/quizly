using Quizly.Entities;

namespace Quizly.Repositories;

public interface IQuestionRepository
{
    List<Question> GetAllQuestions();

    Question? GetQuestionById(int id);

    List<Answer> GetAnswersByIds(List<int> ids);

    Question AddQuestion(Question question);

    Question DeleteQuestion(int id);
}