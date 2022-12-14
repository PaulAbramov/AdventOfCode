// See https://aka.ms/new-console-template for more information

using Day2._1;

int totalPoints = 0;
foreach (var line in File.ReadLines("input.txt"))
{
    var hands = line.Split(" ");

    bool parseOpponentHandSuccess = Enum.TryParse(hands[0], out RockPaperScissorHand opponentHand);
    bool parseMyHandSuccess = Enum.TryParse(hands[1], out RockPaperScissorHand myHand);
    
    if (!parseOpponentHandSuccess || !parseMyHandSuccess)
    {
        continue;
    }

    // add points for my chosen Hand
    totalPoints += (int) myHand;
    
    // check who won
    totalPoints += (int) GameStateChecker.CheckGameState(opponentHand, myHand);
}

Console.WriteLine($"Our total points are: {totalPoints}");