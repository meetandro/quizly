using QuizApp.Entities;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Services;

public class QuestionService(IQuestionRepository questionRepository) : IQuestionService
{
    private readonly IQuestionRepository _questionRepository = questionRepository;

    public List<Question> GetQuestions()
    {
        return _questionRepository.GetQuestions();
    }

    public Question AddQuestion(QuestionViewModel questionViewModel)
    {
        var question = questionViewModel.Question ?? throw new Exception("Question does not exist.");

        if (string.IsNullOrEmpty(question.QuestionText))
        {
            throw new ArgumentNullException(nameof(questionViewModel), "Question text is required.");
        }
        if (question.Answers.Any(a => string.IsNullOrEmpty(a.AnswerText)))
        {
            throw new Exception("All answers must be filled.");
        }

        var correctAnswerIndex = questionViewModel.CorrectAnswerIndex;

        question.Answers[correctAnswerIndex].IsCorrect = true;

        return _questionRepository.AddQuestion(question);
    }

    public Question DeleteQuestion(int id)
    {
        return _questionRepository.DeleteQuestion(id);
    }
}