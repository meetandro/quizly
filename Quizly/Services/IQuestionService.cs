using Quizly.Entities;
using Quizly.Models;

namespace Quizly.Services;

public interface IQuestionService
{
    List<Question> GetAllQuestions();

    Question AddQuestion(QuestionModel questionModel);

    Question DeleteQuestion(int id);
}