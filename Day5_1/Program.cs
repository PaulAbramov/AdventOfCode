/*
 * Supplies are stored in stacks of marked crates,
 * but because the needed supplies are buried under many other crates,
 * the crates need to be rearranged.
 *
 * The Elves just need to know which crate will end up on top of each stack
 *
 * Crates are moved one at a time, so the first crate to be moved ends up below the second and third crates
 * 
 * After the rearrangement procedure completes, what crate ends up on top of each stack?
 */

using Day5_1;

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