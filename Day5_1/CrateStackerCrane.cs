namespace Day5_1;

public class CrateStackerCrane
{
    private readonly List<Stack<char>> crates = new List<Stack<char>>();

    public void Initialize(List<string> stackLines)
    {
        var amountOfStacks = stackLines.First().Count(x => x.Equals('['));
        for (var i = 0; i < amountOfStacks; i++)
        {
            crates.Add(new Stack<char>());
        }

        foreach (var stackline in stackLines)
        {
            PlaceCrateFromLine(string.Concat(" ", stackline));
        }
    }

    /// <summary>
    /// Go through the line from a startindex and search for more crates
    /// we always have a empty space (1 char) before a crate (3 chars) = 4 chars
    /// </summary>
    /// <param name="stackLine"></param>
    /// <param name="startIndex"></param>
    private void PlaceCrateFromLine(string stackLine, int startIndex = 0)
    {
        var index = stackLine.IndexOf('[', startIndex);
        if (index == -1)
        {
            return;
        }

        var crate = stackLine[index + 1];
        var stackIndex = (int)(index / 4);
        crates[stackIndex].Push(crate);
        
        PlaceCrateFromLine(stackLine, index + 2);
    }

    /// <summary>
    /// Pop from one, and push the returned element to the other stack
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="fromStack"></param>
    /// <param name="toStack"></param>
    public void MoveCrates(int amount, int fromStack, int toStack)
    {
        for (var i = 0; i < amount; i++)
        {
            crates[toStack - 1].Push(crates[fromStack - 1].Pop());
        }
    }

    /// <summary>
    /// call the peek method on every Stack and add the crate element to the string
    /// </summary>
    /// <returns></returns>
    public string ReturnTopCratesPerStack()
    {
        return crates.Aggregate(string.Empty, (current, cratesStack) => current + cratesStack.Peek());
    }
}