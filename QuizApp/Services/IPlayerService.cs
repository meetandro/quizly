using QuizApp.Entities;

namespace QuizApp.Services;

public interface IPlayerService
{
    public List<Player> GetAllPlayers();

    public Player AddPlayer(Player player);

    public Player DeletePlayer(int id);
}