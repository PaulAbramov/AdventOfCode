/*
 * As you watch the crane operator expertly rearrange the crates,
 * you notice the process isn't following your prediction.
 * 
 * Some mud was covering the writing on the side of the crane,
 * and you quickly wipe it away.
 * The crane isn't a CrateMover 9000 - it's a CrateMover 9001.
 *
 * The CrateMover 9001 is notable for many new and
 * exciting features: air conditioning, leather seats, an extra cup holder,
 * and the ability to pick up and move multiple crates at once.
 *
 * Before the rearrangement process finishes,
 * update your simulation so that the Elves know where they should stand to be ready to unload the final supplies.
 * After the rearrangement procedure completes, what crate ends up on top of each stack?
 */

using Day5_2;

var lines = File.ReadLines("input.txt").ToList();
var stacklines = new List<string>();

CrateStackerCrane crane = new CrateStackerCrane();

foreach (var line in lines)
{
    if (line.Any(x => x.Equals('[')))
    {
        stacklines.Add(line);
        continue;
    }

    if (string.IsNullOrEmpty(line))
    {
        stacklines.Reverse();

        crane.Initialize(stacklines);

        continue;
    }

    if (line.StartsWith("move"))
    {
        var indexOfFrom = line.IndexOf("from", StringComparison.Ordinal);
        var indexOfTo = line.IndexOf("to", StringComparison.Ordinal);

        var amountString = line.Substring(5, indexOfFrom - 5).Trim();
        var amount = int.Parse(amountString);

        var fromStackString = line.Substring(indexOfFrom + 5, 1).Trim();
        var fromStack = int.Parse(fromStackString);

        var toStackString = line.Substring(indexOfTo + 2);
        var toStack = int.Parse(toStackString);

        crane.MoveCrates(amount, fromStack, toStack);
    }
}

Console.WriteLine(crane.ReturnTopCratesPerStack());