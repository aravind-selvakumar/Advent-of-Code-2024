
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Read initial arrangement of stones from file
        
        string filePath = "D:\\GitLabSource\\AoC2024\\Day11\\Day11\\Day11InputData.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Read single line of numbers separated by spaces
        string inputLine = File.ReadAllText(filePath).Trim();
       

        //part1(inputLine);
        part2(inputLine);

        
    }

    static void part2(string inputLine)
    {
        // Dictionary to count occurrences of each stone
        Dictionary<string, long> stoneCount = new Dictionary<string, long>();
        foreach (var stone in inputLine.Split(' '))
        {
            if (stoneCount.ContainsKey(stone))
            {
                stoneCount[stone]++;
            }
            else
            {
                stoneCount[stone] = 1;
            }
        }

        int blinks = 75;

        for (int i = 0; i < blinks; i++)
        {
            Dictionary<string, long> newStoneCount = new Dictionary<string, long>();

            foreach (var kvp in stoneCount)
            {
                string currentStone = kvp.Key;
                long count = kvp.Value;

                // Transform the stone based on its type
                string[] transformed = Transform(currentStone);

                foreach (var newStone in transformed)
                {
                    if (newStoneCount.ContainsKey(newStone))
                    {
                        newStoneCount[newStone] += count;
                    }
                    else
                    {
                        newStoneCount[newStone] = count;
                    }
                }
            }

            // Update the stone counts for the next iteration
            stoneCount = newStoneCount;
        }

        long totalStones = 0;
        foreach (var count in stoneCount.Values)
        {
            totalStones += count;
        }

        Console.WriteLine($"Number of stones after {blinks} blinks: {totalStones}");

    }

    static string[] Transform(string stone)
    {
        if (stone == "0")
        {
            return new[] { "1" };
        }
        else if (stone.Length % 2 == 0)
        {
            // Split stone into two halves
            int mid = stone.Length / 2;
            string left = stone.Substring(0, mid).TrimStart('0');
            string right = stone.Substring(mid).TrimStart('0');

            return new[]
            {
                string.IsNullOrEmpty(left) ? "0" : left,
                string.IsNullOrEmpty(right) ? "0" : right
            };
        }
        else
        {
            // Multiply the stone's number by 2024
            long num = long.Parse(stone);
            return new[] { (num * 2024).ToString() };
        }
    }

    static void part1(string inputLine)
    {
        List<string> stones = new List<string>(inputLine.Split(' '));
        int blinksPart1 = 25;
        

        for (int i = 0; i < blinksPart1; i++)
        {
            stones = Blink(stones);
        }

        Console.WriteLine($"Number of stones after {blinksPart1} blinks(Part 1): {stones.Count}");
    }
    static List<string> Blink(List<string> stones)
    {
        List<string> newStones = new List<string>();

        foreach (string stone in stones)
        {
            if (stone == "0")
            {
                newStones.Add("1");
            }
            else if (stone.Length % 2 == 0)
            {
                // Split stone into two halves
                int mid = stone.Length / 2;
                string left = stone.Substring(0, mid).TrimStart('0');
                string right = stone.Substring(mid).TrimStart('0');

                newStones.Add(string.IsNullOrEmpty(left) ? "0" : left);
                newStones.Add(string.IsNullOrEmpty(right) ? "0" : right);
            }
            else
            {
                // Multiply the stone's number by 2024
                long num = long.Parse(stone);
                newStones.Add((num * 2024).ToString());
            }
        }

        return newStones;
    }
}
