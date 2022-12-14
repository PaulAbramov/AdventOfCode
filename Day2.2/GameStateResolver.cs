namespace Day2._2;

public class GameStateChecker
{
    public static GameState CheckGameState(RockPaperScissorHand opponent, RockPaperScissorHand myHand) => opponent switch
    {
        RockPaperScissorHand.A => myHand switch
        {
            RockPaperScissorHand.X => GameState.Y,
            RockPaperScissorHand.Y => GameState.Z,
            RockPaperScissorHand.Z => GameState.X,
            _ => throw new ArgumentOutOfRangeException(nameof(myHand), myHand, $"Not expected our Hand: {myHand}")
        },
        RockPaperScissorHand.B => myHand switch
        {
            RockPaperScissorHand.X => GameState.X,
            RockPaperScissorHand.Y => GameState.Y,
            RockPaperScissorHand.Z => GameState.Z,
            _ => throw new ArgumentOutOfRangeException(nameof(myHand), myHand, $"Not expected our Hand: {myHand}")
        },
        RockPaperScissorHand.C => myHand switch
        {
            RockPaperScissorHand.X => GameState.Z,
            RockPaperScissorHand.Y => GameState.X,
            RockPaperScissorHand.Z => GameState.Y,
            _ => throw new ArgumentOutOfRangeException(nameof(myHand), myHand, $"Not expected our Hand: {myHand}")
        },
        _ => throw new ArgumentOutOfRangeException(nameof(opponent), opponent, $"Not expected opponent Hand: {opponent}")
    };
    
    public static RockPaperScissorHand CheckHandToPlay(RockPaperScissorHand opponent, GameState gameState) => opponent switch
    {
        RockPaperScissorHand.A => gameState switch
        {
            GameState.X => RockPaperScissorHand.Z,
            GameState.Y => RockPaperScissorHand.X,
            GameState.Z => RockPaperScissorHand.Y,
            _ => throw new ArgumentOutOfRangeException(nameof(gameState), gameState, $"Not expected game state: {gameState}")
        },
        RockPaperScissorHand.B => gameState switch
        {
            GameState.X => RockPaperScissorHand.X,
            GameState.Y => RockPaperScissorHand.Y,
            GameState.Z => RockPaperScissorHand.Z,
            _ => throw new ArgumentOutOfRangeException(nameof(gameState), gameState, $"Not expected game state: {gameState}")
        },
        RockPaperScissorHand.C => gameState switch
        {
            GameState.X => RockPaperScissorHand.Y,
            GameState.Y => RockPaperScissorHand.Z,
            GameState.Z => RockPaperScissorHand.X,
            _ => throw new ArgumentOutOfRangeException(nameof(gameState), gameState, $"Not expected game state: {gameState}")
        },
        _ => throw new ArgumentOutOfRangeException(nameof(opponent), opponent, $"Not expected opponent Hand: {opponent}")
    };
}