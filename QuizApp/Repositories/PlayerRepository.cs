using Microsoft.EntityFrameworkCore;
using QuizApp.Context;
using QuizApp.Models;

namespace QuizApp.Repositories;

public class PlayerRepository(QuizAppDbContext context) : IPlayerRepository
{
    private readonly QuizAppDbContext _context = context;

    public List<Player> GetPlayers()
    {
        return _context.Players
            .ToList();
    }

    public Player? GetPlayerById(int id)
    {
        return _context.Players
            .Include("Rounds")
            .FirstOrDefault(p => p.Id == id);
    }

    public Player? GetPlayerByUsername(string username)
    {
        return _context.Players
            .Include("Rounds")
            .FirstOrDefault(p => p.Username == username);
    }

    public Player UpdatePlayer(Player player)
    {
        _context.Players.Update(player);
        _context.SaveChanges();
        var updatedPlayer = GetPlayerById(player.Id);
        return updatedPlayer;
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