// See https://aka.ms/new-console-template for more information

// Create a comparer that sorts the items in descending order

IComparer<int> descendingComparer = Comparer<int>.Create((x, y) => y - x);

// Create a SortedSet<T> collection with a maximum capacity of 3
// and use the custom comparer to sort the items in descending order
var sortedSet = new SortedSet<int>(descendingComparer);

const int topElvesCount = 3;
var currentElvCalories = 0;
foreach (var line in File.ReadLines("input.txt"))
{
    if (string.IsNullOrEmpty(line))
    {
        sortedSet.Add(currentElvCalories);

        if (sortedSet.Count > topElvesCount)
        {
            sortedSet.Remove(sortedSet.ElementAt(topElvesCount));
        }

        currentElvCalories = 0;

        continue;
    }

    currentElvCalories += int.Parse(line);
}

for (var i = 0; i < topElvesCount; i++)
{
    Console.WriteLine($"The Elv in position {i + 1} has {sortedSet.ElementAt(i)} Calories.");
}

Console.WriteLine($"Which means, in total we have {sortedSet.Sum()} Calories");