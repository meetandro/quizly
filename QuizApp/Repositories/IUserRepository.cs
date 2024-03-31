using QuizApp.Models;

namespace QuizApp.Repositories;

public interface IUserRepository
{
    public User AddUser(User user);
    public User DeleteUser(int id);
    public User UpdateUserScore(int id);
    public SubmittedAnswer SubmitAnswer(int userId, int answerId);
}