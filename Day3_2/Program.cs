/*
 * As you finish identifying the misplaced items, the Elves come to you with another issue.
 *
 * For safety, the Elves are divided into groups of three.
 * Every Elf carries a badge that identifies their group.
 * For efficiency, within each group of three Elves, the badge is the only item type carried by all three Elves.
 * That is, if a group's badge is item type B, then all three Elves will have item type B somewhere in their rucksack,
 * and at most two of the Elves will be carrying any other item type.
 *
 * The problem is that someone forgot to put this year's updated authenticity sticker on the badges.
 * All of the badges need to be pulled out of the rucksacks so the new authenticity stickers can be attached.
 *
 * Additionally, nobody wrote down which item type corresponds to each group's badges.
 * The only way to tell which item type is the right one is by finding the one item type that is common between all three Elves in each group.
 *
 * Every set of three lines in your list corresponds to a single group, but each group can have a different badge item type.
 *
 * Find the item type that corresponds to the badges of each three-Elf group.
 * What is the sum of the priorities of those item types?
 */

var lines = File.ReadLines("input.txt").ToList();

var totalSum = 0;
string stringToCompare = "";
for (int i = 0; i <= lines.Count; i++)
{
    // we only want to check every 3 lines
    if (i % 3 == 0)
    {
        if (!string.IsNullOrEmpty(stringToCompare))
        {
            foreach (var character in stringToCompare)
            {
                int index = (int)character % 32;
    
                // a-z is 1 - 26
                // A-Z is 27 - 52
                if (char.IsUpper(character))
                {
                    index += 26;
                }

                totalSum += index;
            }
        }

        // End condition, as we do not want to run into exceptions or other problems after the last line
        if (lines.Count == i)
        {
            break;
        }
        
        // Reset to the first of the 3 lines
        stringToCompare = lines[i];
        continue;
    }
    
    // compare the second string to the first and look for common chars
    // next iteration compare the common chars from first and second string to the third string, and look for common chars
    stringToCompare = string.Concat(stringToCompare.Intersect(lines[i]));
}

Console.WriteLine($"Sum of priorities is {totalSum}");