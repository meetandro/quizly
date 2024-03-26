using Microsoft.EntityFrameworkCore;
using QuizApp.Context;
using QuizApp.Models;

namespace QuizApp.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly QuizAppDbContext _context;

    public QuestionRepository(QuizAppDbContext context)
    {
        _context = context;
    }

    public List<Question> GetQuestions()
    {
        return _context.Questions
            .Include("Answers")
            .ToList();
    }

    public Question AddQuestion(Question question, int correctAnswerIndex)
    {
        question.Answers[correctAnswerIndex].IsCorrect = true;
        _context.Questions.Add(question);
        _context.SaveChanges();
        return question;
    }

    public Question DeleteQuestion(int id)
    {
        var question = _context.Questions.FirstOrDefault(q => q.Id == id);
        _context.Questions.Remove(question);
        _context.SaveChanges();
        return question;
    }
}