using Microsoft.EntityFrameworkCore;
using QuizApp.Models;

namespace QuizApp.Context;

public class QuizAppDbContext : DbContext
{
    public QuizAppDbContext(DbContextOptions<QuizAppDbContext> options) : base(options) { }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }
}