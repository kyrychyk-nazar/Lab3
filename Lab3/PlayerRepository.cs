namespace Лаб2;

public class PlayerRepository : IPlayerRepository
{
    private readonly DbContext context;

    public PlayerRepository(DbContext context)
    {
        this.context = context;
    }

    public void AddPlayer(GameAccount player)
    {
        context.Players.Add(player);
    }

    public void RemovePlayer(GameAccount player)
    {
        if (context.Players.Contains(player))
        {
            context.Players.Remove(player);
        }
    }

    public GameAccount? GetPlayerByName(string username)
    {
        return context.Players.Find(p => p.Username == username);
    }

    public List<GameAccount> GetAllPlayers()
    {
        return context.Players;
    }
}