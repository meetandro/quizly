using QuizApp.Entities;

namespace QuizApp.Services;

public interface IPlayerService
{
    List<Player> GetAllPlayers();

    Player AddPlayer(Player player);

    Player DeletePlayer(int id);
}