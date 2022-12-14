namespace Day2._1;

public class GameStateChecker
{
    public static GameState CheckGameState(RockPaperScissorHand opponent, RockPaperScissorHand myHand) => opponent switch
    {
        RockPaperScissorHand.A => myHand switch
        {
            RockPaperScissorHand.X => GameState.Tie,
            RockPaperScissorHand.Y => GameState.Won,
            RockPaperScissorHand.Z => GameState.Lost,
            _ => throw new ArgumentOutOfRangeException(nameof(myHand), myHand, $"Not expected our Hand: {myHand}")
        },
        RockPaperScissorHand.B => myHand switch
        {
            RockPaperScissorHand.X => GameState.Lost,
            RockPaperScissorHand.Y => GameState.Tie,
            RockPaperScissorHand.Z => GameState.Won,
            _ => throw new ArgumentOutOfRangeException(nameof(myHand), myHand, $"Not expected our Hand: {myHand}")
        },
        RockPaperScissorHand.C => myHand switch
        {
            RockPaperScissorHand.X => GameState.Won,
            RockPaperScissorHand.Y => GameState.Lost,
            RockPaperScissorHand.Z => GameState.Tie,
            _ => throw new ArgumentOutOfRangeException(nameof(myHand), myHand, $"Not expected our Hand: {myHand}")
        },
        _ => throw new ArgumentOutOfRangeException(nameof(opponent), opponent, $"Not expected opponent Hand: {opponent}")
    };
}