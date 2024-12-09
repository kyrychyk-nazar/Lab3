namespace Лаб2;

public class TrainingGame : BaseGame
{
    public TrainingGame(string playerName, string opponentName) 
        : base(playerName, opponentName, false) { }

    public override int CalculateRating()
    {
        return 0;
    }
}