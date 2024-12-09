namespace Лаб2;

public interface IPlayerService
{
    void AddPlayer(string username, int initialRating, bool isPayToWin = false);
    GameAccount? GetPlayerByName(string username);
    List<GameAccount> GetAllPlayers();
    void RemovePlayer(string username); 
}