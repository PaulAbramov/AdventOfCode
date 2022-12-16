/*
 * It seems like there is still quite a bit of duplicate work planned.
 * Instead, the Elves would like to know the number of pairs that overlap at all.
 *
 * In how many assignment pairs do the ranges overlap?
 */

var lines = File.ReadLines("input.txt").ToList();

int counter = 0;
foreach (var line in lines)
{
    var ranges = line.Split(",");

    var firstRange = ranges[0].Split("-");
    var secondRange = ranges[1].Split("-");

    int startFirstRange = int.Parse(firstRange[0]);
    int endFirstRange = int.Parse(firstRange[1]);

    int startSecondRange = int.Parse(secondRange[0]);
    int endSecondRange = int.Parse(secondRange[1]);

    if (startFirstRange <= startSecondRange
        && endFirstRange >= startSecondRange)
    {
        counter++;
        continue;
    }
    else if (startFirstRange <= endSecondRange
             && endFirstRange >= endSecondRange)
    {
        counter++;
        continue;
    }

    if (startFirstRange >= startSecondRange
        && startFirstRange <= endSecondRange)
    {
        counter++;
        continue;
    }
    else if (endFirstRange >= startSecondRange
             && endFirstRange <= endSecondRange)
    {
        counter++;
        continue;
    }
}

Console.WriteLine($"There are {counter} pairs, fully containing or overlapping");