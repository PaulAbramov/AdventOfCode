/*
 * Your device's communication system is correctly detecting packets, but still isn't working.
 * It looks like it also needs to look for messages.
 *
 * A start-of-message marker is just like a start-of-packet marker, except it consists of 14 distinct characters rather than 4.
 *
 * Here are the first positions of start-of-message markers for all of the above examples:
 *
 * mjqjpqmgbljsphdztnvjfqwrcgsmlb: first marker after character 19
 * bvwbjplbgvbhsrlpgdmjqwftvncz: first marker after character 23
 * nppdvjthqldpwncqszvftbrmjlhg: first marker after character 23
 * nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg: first marker after character 29
 * zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw: first marker after character 26
 *
 * How many characters need to be processed before the first start-of-message marker is detected?
 */

Queue<char> marker = new Queue<char>();

var lines = File.ReadLines("input.txt").ToList();

int counter;
for (counter = 0; counter < lines[0].Length; counter++)
{
    marker.Enqueue(lines[0][counter]);
    if (marker.Count > 14)
    {
        marker.Dequeue();
    }

    if (marker.GroupBy(x => x).Count() == 14)
    {
        break;
    }
}

Console.WriteLine($"Marker set at position: {counter + 1}");