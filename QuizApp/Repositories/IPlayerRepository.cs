using QuizApp.Entities;

namespace QuizApp.Repositories;

public interface IPlayerRepository
{
    public List<Player> GetAllPlayers();

    public Player? GetPlayerById(int id);

    public Player? GetPlayerByUsername(string username);

    public Player UpdatePlayer(Player player);

    public Player AddPlayer(Player player);

    public Player DeletePlayer(int id);
}