// See https://aka.ms/new-console-template for more information

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