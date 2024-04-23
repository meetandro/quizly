using QuizApp.Models;

namespace QuizApp.Repositories;

public interface IPlayerRepository
{
    public List<Player> GetPlayers();
    public Player GetPlayerById(int id);
    public Player GetPlayerByUsername(string username);
    public Player UpdatePlayer(Player player);
    public Player AddPlayer(Player player);
    public Player DeletePlayer(int id);
}