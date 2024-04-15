using QuizApp.Models;

namespace QuizApp.Repositories;

public interface IPlayerRepository
{
    public List<Player> GetPlayers();
    public Player AddPlayer(Player player);
    public Player DeletePlayer(int id);
}