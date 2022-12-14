﻿/*
 * One Elf has the important job of loading all of the rucksacks with supplies for the jungle journey.
 * Unfortunately, that Elf didn't quite follow the packing instructions, and so a few items now need to be rearranged.
 *
 * Each rucksack has two large compartments. All items of a given type are meant to go into exactly one of the two compartments.
 * The Elf that did the packing failed to follow this rule for exactly one item type per rucksack.
 *
 * The Elves have made a list of all of the items currently in each rucksack (your puzzle input), but they need your help finding the errors.
 * Every item type is identified by a single lowercase or uppercase letter (that is, a and A refer to different types of items).
 *
 * The list of items for each rucksack is given as characters all on a single line.
 * A given rucksack always has the same number of items in each of its two compartments,
 * so the first half of the characters represent items in the first compartment,
 * while the second half of the characters represent items in the second compartment.
 *
 * To help prioritize item rearrangement, every item type can be converted to a priority:
 *  Lowercase item types a through z have priorities 1 through 26.
 *  Uppercase item types A through Z have priorities 27 through 52.
 *
 * Find the item type that appears in both compartments of each rucksack.
 * What is the sum of the priorities of those item types?
 */

int totalSum = 0;

foreach (var line in File.ReadLines("input.txt"))
{
    var firstHalf = line[..(line.Length / 2)];
    var secondHalf = line[(line.Length / 2)..];

    var commonChars = firstHalf.Intersect(secondHalf);

    var characters = commonChars.ToList();
    foreach (var character in characters)
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

Console.WriteLine($"Sum of priorities is {totalSum}");