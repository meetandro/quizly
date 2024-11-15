using Microsoft.EntityFrameworkCore;
using Quizly.Context;
using Quizly.Entities;

namespace Quizly.Repositories;

public class QuestionRepository(QuizlyDbContext context) : IQuestionRepository
{
    private readonly QuizlyDbContext _context = context;

    public List<Question> GetAllQuestions()
    {
        return _context.Questions
            .Include("Answers")
            .ToList();
    }

    public Question? GetQuestionById(int id)
    {
        return _context.Questions
            .Include("Answers")
            .FirstOrDefault(q => q.Id == id);
    }

    public List<Answer> GetAnswersByIds(List<int> ids)
    {
        return _context.Answers
            .Where(a => ids.Contains(a.Id))
            .ToList();
    }

    public Question AddQuestion(Question question)
    {
        _context.Questions.Add(question);
        _context.SaveChanges();
        return question;
    }

    public Question DeleteQuestion(int id)
    {
        var question = GetQuestionById(id);
        _context.Questions.Remove(question);
        _context.SaveChanges();
        return question;
    }
}