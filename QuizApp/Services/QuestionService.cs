using QuizApp.Entities;
using QuizApp.Exceptions;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Services;

public class QuestionService(IQuestionRepository questionRepository) : IQuestionService
{
    private readonly IQuestionRepository _questionRepository = questionRepository;

    public List<Question> GetAllQuestions()
    {
        return _questionRepository.GetAllQuestions();
    }

    public Question AddQuestion(QuestionModel questionModel)
    {
        if (string.IsNullOrEmpty(questionModel.QuestionText))
        {
            throw new EmptyInputException("Question text is required.");
        }
        if (questionModel.Answers.Any(a => string.IsNullOrEmpty(a.AnswerText)))
        {
            throw new EmptyInputException("All answers must be filled.");
        }

        var question = new Question
        {
            QuestionText = questionModel.QuestionText,
            Answers = questionModel.Answers,
        };

        int correctAnswerIndex = questionModel.CorrectAnswerIndex;
        question.Answers[correctAnswerIndex].IsCorrect = true;

        return _questionRepository.AddQuestion(question);
    }

    public Question DeleteQuestion(int id)
    {
        return _questionRepository.DeleteQuestion(id);
    }
}