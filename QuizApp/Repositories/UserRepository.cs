using QuizApp.Context;
using QuizApp.Models;

namespace QuizApp.Repositories;

public class UserRepository : IUserRepository
{
    private readonly QuizAppDbContext _context;

    public UserRepository(QuizAppDbContext context)
    {
        _context = context;
    }

    public User AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        _context.Users.Remove(user);
        _context.SaveChanges();
        return user;
    }

    public User UpdateUserScore(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        user.Score++;
        _context.Users.Update(user);
        _context.SaveChanges();
        return user;
    }

    public SubmittedAnswer SubmitAnswer(int userId, int answerId)
    {
        var answer = _context.Answers.FirstOrDefault(a => a.Id == answerId);
        var submittedAnswer = new SubmittedAnswer
        {
            UserId = userId,
            AnswerId = answerId,
            IsCorrect = answer.IsCorrect
        };

        _context.SubmittedAnswers.Add(submittedAnswer);
        _context.SaveChanges();
        return submittedAnswer;
    }
}