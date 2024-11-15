using Microsoft.EntityFrameworkCore;
using Quizly.Context;
using Quizly.Entities;

namespace Quizly.Repositories;

public class PlayerRepository(QuizlyDbContext context) : IPlayerRepository
{
    private readonly QuizlyDbContext _context = context;

    public List<Player> GetAllPlayers()
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

    public Player AddPlayer(Player player)
    {
        _context.Players.Add(player);
        _context.SaveChanges();
        return player;
    }

    public Player UpdatePlayer(Player player)
    {
        _context.Players.Update(player);
        _context.SaveChanges();
        var updatedPlayer = GetPlayerById(player.Id);
        return updatedPlayer;
    }

    public Player DeletePlayer(int id)
    {
        var player = GetPlayerById(id);
        _context.Players.Remove(player);
        _context.SaveChanges();
        return player;
    }
}