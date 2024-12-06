        
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        //part1();
        part2();
    }


    static void part2()
    {
        // File path where the grid is stored
        string filePath = @"C:\source\AdventOfCode2024\AdventOfCode2024\Day04\Day04InputData.txt";

        // Read the grid from the file
        string[] grid = ReadGridFromFile(filePath);

        // Define the word to search for (the needle)
        string needle = "MAS";
        int rows = grid.Length;
        int cols = grid[0].Length;

        // Directions array: Right, Down, Left, Up, Diagonal Down-Right, Diagonal Down-Left, Diagonal Up-Right, Diagonal Up-Left
        int[] dRow = { 0, 1, 0, -1, 1, 1, -1, -1 };
        int[] dCol = { 1, 0, -1, 0, 1, -1, 1, -1 };

        int count = 0;

        // Search through the haystack (grid)
        for (int row = 1; row < rows-1; row++)
        {
            for (int col = 1; col < cols-1; col++)
            {
                if (grid[row][col].Equals('A'))
                {
                    if (((grid[row-1][col-1].Equals('M') && grid[row + 1][col + 1].Equals('S')) ||
                        (grid[row - 1][col - 1].Equals('S') && grid[row + 1][col + 1].Equals('M')))
                         &&
                       ((grid[row - 1][col + 1].Equals('M') && grid[row + 1][col - 1].Equals('S')) ||
                        (grid[row - 1][col + 1].Equals('S') && grid[row + 1][col - 1].Equals('M'))))
                        {
                        count++;
                    }
                        
                }
            }
        }
        Console.WriteLine(count);
    }

    static void part1()
    {
        // File path where the grid is stored
        string filePath = @"C:\Users\selvabh\source\experimentation\AdventOfCode2024\AdventOfCode2024\Day04\Day04InputData.txt";

        // Read the grid from the file
        string[] grid = ReadGridFromFile(filePath);

        // Define the word to search for (the needle)
        string needle = "XMAS";
        int rows = grid.Length;
        int cols = grid[0].Length;

        // Directions array: Right, Down, Left, Up, Diagonal Down-Right, Diagonal Down-Left, Diagonal Up-Right, Diagonal Up-Left
        int[] dRow = { 0, 1, 0, -1, 1, 1, -1, -1 };
        int[] dCol = { 1, 0, -1, 0, 1, -1, 1, -1 };

        int count = 0;

        // Search through the haystack (grid)
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // Look for the first letter 'X' in the grid (needle)
                if (grid[row][col] == needle[0])
                {
                    // For each direction, check if we can form the word "XMAS"
                    for (int direction = 0; direction < 8; direction++)
                    {
                        // Check if the word fits in the current direction
                        if (IsValid(row, col, dRow[direction], dCol[direction], rows, cols, needle.Length, grid))
                        {
                            // Check if the word matches
                            if (MatchWord(row, col, dRow[direction], dCol[direction], needle, grid))
                            {
                                count++;
                            }
                        }
                    }
                }
            }
        }

        // Output the result
        Console.WriteLine($"The word '{needle}' appears {count} times in the grid.");
    }
    // Read the grid from a file
    static string[] ReadGridFromFile(string filePath)
    {
        try
        {
            // Read all lines from the file and return them as an array of strings
            return File.ReadAllLines(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return new string[0]; // Return an empty array if there's an error
        }
    }

    // Check if it's within the grid bounds
    static bool IsValid(int row, int col, int dRow, int dCol, int rows, int cols, int length, string[] grid)
    {
        int endRow = row + (dRow * (length - 1));
        int endCol = col + (dCol * (length - 1));

        // Check if the ending position is outside of the grid bounds
        return (endRow >= 0 && endRow < rows) && (endCol >= 0 && endCol < cols);
    }

    // Check if the word matches in the current direction
    static bool MatchWord(int row, int col, int dRow, int dCol, string needle, string[] grid)
    {
        for (int i = 0; i < needle.Length; i++)
        {
            if (grid[row][col] != needle[i])
            {
                return false;
            }
            row += dRow;
            col += dCol;
        }
        return true;
    }
}
