using Microsoft.EntityFrameworkCore;
using QuizApp.Context;
using QuizApp.Entities;

namespace QuizApp.Repositories;

public class QuestionRepository(QuizAppDbContext context) : IQuestionRepository
{
    private readonly QuizAppDbContext _context = context;

    public List<Question> GetQuestions()
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
        var question = _context.Questions.FirstOrDefault(q => q.Id == id);
        _context.Questions.Remove(question);
        _context.SaveChanges();
        return question;
    }
}