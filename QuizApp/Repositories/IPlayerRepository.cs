using QuizApp.Entities;

namespace QuizApp.Repositories;

public interface IPlayerRepository
{
    List<Player> GetAllPlayers();

    Player? GetPlayerById(int id);

    Player? GetPlayerByUsername(string username);

    Player AddPlayer(Player player);

    Player UpdatePlayer(Player player);

    Player DeletePlayer(int id);
}