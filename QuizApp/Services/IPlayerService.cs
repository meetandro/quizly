using QuizApp.Entities;

namespace QuizApp.Services;

public interface IPlayerService
{
    public List<Player> GetPlayers();
    public Player AddPlayer(Player player);
    public Player DeletePlayer(int id);
}