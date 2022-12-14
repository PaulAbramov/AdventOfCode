/*
 * https://adventofcode.com/2022/day/1
 *
 * One important consideration is food - in particular, the number of Calories each Elf is carrying (your puzzle input).
 * This list represents the Calories of the food carried by all Elves
 *
 * In case the Elves get hungry and need extra snacks, they need to know which Elf to ask:
 * they'd like to know how many Calories are being carried by the Elf carrying the most Calories.
 *
 * Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?
 */

Tuple<int, long>? biggestAmountOfCalories = null;
int counter = 0;
long currentElvCalories = 0;
foreach (var line in File.ReadLines("input.txt"))
{
    if (string.IsNullOrEmpty(line))
    {
        biggestAmountOfCalories ??= new Tuple<int, long>(counter, currentElvCalories);

        if (biggestAmountOfCalories.Item2 < currentElvCalories)
        {
            biggestAmountOfCalories = new Tuple<int, long>(counter, currentElvCalories);
        }

        counter++;
        currentElvCalories = 0;

        continue;
    }

    currentElvCalories += long.Parse(line);
}


if (biggestAmountOfCalories != null)
{
    Console.WriteLine(
        $"The {biggestAmountOfCalories.Item1}. Elv has the most Calories with {biggestAmountOfCalories.Item2}");
}