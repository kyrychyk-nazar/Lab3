namespace Лаб2;

public class StandardGame : BaseGame
{
    public int Rating { get; private set; }

    public StandardGame(string playerName, string opponentName, int rating, bool isWin) 
        : base(playerName, opponentName, isWin)
    {
        if (rating <= 0)
            throw new ArgumentException("Рейтинг повинен бути вище 0");

        Rating = rating;
    }

    public override int CalculateRating()
    {
        return Rating;
    }
}