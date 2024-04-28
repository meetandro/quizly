using Microsoft.EntityFrameworkCore;
using QuizApp.Entities;

namespace QuizApp.Context;

public class QuizAppDbContext(DbContextOptions<QuizAppDbContext> options) : DbContext(options)
{
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Round> Rounds { get; set; }
    public DbSet<Attempt> Attempts { get; set; }
}