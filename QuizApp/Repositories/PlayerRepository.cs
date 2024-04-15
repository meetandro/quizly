using QuizApp.Context;
using QuizApp.Models;

namespace QuizApp.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly QuizAppDbContext _context;

    public PlayerRepository(QuizAppDbContext context)
    {
        _context = context;
    }

    public List<Player> GetPlayers()
    {
        return _context.Players
            .ToList();
    }

    public Player AddPlayer(Player player)
    {
        _context.Players.Add(player);
        _context.SaveChanges();
        return player;
    }

    public Player DeletePlayer(int id)
    {
        var player = _context.Players.FirstOrDefault(p => p.Id == id);
        _context.Players.Remove(player);
        _context.SaveChanges();
        return player;
    }
}