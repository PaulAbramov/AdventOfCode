/*
 * https://adventofcode.com/2022/day/2
 *
 * The Elf finishes helping with the tent and sneaks back over to you.
 * "Anyway, the second column says how the round needs to end:
 *  X means you need to lose,
 *  Y means you need to end the round in a draw,
 *  and Z means you need to win. Good luck!"
 *
 * The total score is still calculated in the same way,
 * but now you need to figure out what shape to choose so the round ends as indicated.
 *
 * Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide?
 */

using Day2._2;

int totalPoints = 0;
foreach (var line in File.ReadLines("input.txt"))
{
    var hands = line.Split(" ");

    bool parseOpponentHandSuccess = Enum.TryParse(hands[0], out RockPaperScissorHand opponentHand);
    bool parseGameState = Enum.TryParse(hands[1], out GameState gameState);
    
    if (!parseOpponentHandSuccess || !parseGameState)
    {
        continue;
    }

    // add points for my chosen Hand
    totalPoints += (int) gameState;
    
    // check who won
    totalPoints += (int) GameStateChecker.CheckHandToPlay(opponentHand, gameState);
}

Console.WriteLine($"Our total points are: {totalPoints}");