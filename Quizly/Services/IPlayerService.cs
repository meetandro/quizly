using Quizly.Entities;

namespace Quizly.Services;

public interface IPlayerService
{
    List<Player> GetAllPlayers();

    Player AddPlayer(Player player);

    Player DeletePlayer(int id);
}