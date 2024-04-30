using QuizApp.Entities;
using QuizApp.Models;

namespace QuizApp.Services;

public interface IQuestionService
{
    List<Question> GetAllQuestions();

    Question AddQuestion(QuestionModel questionModel);

    Question DeleteQuestion(int id);
}