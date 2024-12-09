namespace Лаб2;

public interface IPlayerRepository
{
    void AddPlayer(GameAccount player);
    void RemovePlayer(GameAccount player);
    GameAccount? GetPlayerByName(string username);
    List<GameAccount> GetAllPlayers();
}