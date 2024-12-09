namespace Лаб2;

public interface IGameService
{
    void CreateGame(BaseGame game);
    BaseGame? GetGameById(Guid gameId);
    List<BaseGame> GetAllGames();
    void GetStats();
}