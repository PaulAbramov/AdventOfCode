/*
 * https://adventofcode.com/2022/day/1
 *
 * By the time you calculate the answer to the Elves' question,
 * they've already realized that the Elf carrying the most Calories of food might eventually run out of snacks.
 *
 * To avoid this unacceptable situation,
 * the Elves would instead like to know the total Calories carried by the top three Elves carrying the most Calories.
 * That way, even if one of those Elves runs out of snacks, they still have two backups.
 *
 * Find the top three Elves carrying the most Calories.
 * How many Calories are those Elves carrying in total?
 */

// Create a comparer that sorts the items in descending order
IComparer<int> descendingComparer = Comparer<int>.Create((x, y) => y - x);
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