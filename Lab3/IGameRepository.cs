namespace Лаб2;

public interface IGameRepository
{
    BaseGame? GetGameById(Guid gameId);
    void CreateGame(BaseGame game);
    List<BaseGame> GetAllGames();
    void GetStats();
}