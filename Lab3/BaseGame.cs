namespace Лаб2;

public abstract class BaseGame
{
    public string OpponentName { get; set; }
    public string PlayerName { get; set; } 
    public Guid GameId { get; private set; }
    public bool IsWin { get; set; }

    protected BaseGame(string playerName, string opponentName, bool isWin)
    {
        PlayerName = playerName;
        OpponentName = opponentName;
        GameId = Guid.NewGuid();
        IsWin = isWin;
    }

    public abstract int CalculateRating();
}