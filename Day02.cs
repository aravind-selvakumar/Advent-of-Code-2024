// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// Initialize  lists to store the columns


        // Define the path to the file containing reports
string filePath = @"C:\source\experimentation\AdventOfCode2024\AdventOfCode2024\Day02\Day02InputData.txt";


int safeReportsCount = 0;


try
{
    // Open the file and read it line by line
    using (StreamReader sr = new StreamReader(filePath))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            // Skip empty lines
            if (string.IsNullOrWhiteSpace(line)) continue;

            // Split the line by spaces to get individual levels
            List<int> report = new List<int>();
            string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                if (int.TryParse(part, out int level))
                {
                    report.Add(level);
                }
                else
                {
                    Console.WriteLine($"Invalid input in report: {line}");
                    break;
                }
            }

            // Check if the report is safe or if removing one level makes it safe
            if (IsSafe(report))
            {
                Console.WriteLine("Safe: " + string.Join(" ", report));
                safeReportsCount++;  // Increment the safe report counter
            }
            else if (CanBeMadeSafeByRemovingOneLevel(report))
            {
                Console.WriteLine("Safe after removing one level: " + string.Join(" ", report));
                safeReportsCount++;  // Increment the safe report counter
            }
            else
            {
                Console.WriteLine("Unsafe: " + string.Join(" ", report));
            }
        }
    }

    // Output the total count of safe reports
    Console.WriteLine($"\nTotal Safe Reports: {safeReportsCount}");
}
catch (Exception ex)
{
    Console.WriteLine("Error reading file: " + ex.Message);
}
  
    // Method to check if a report is safe based on the rules
    static bool IsSafe(List<int> report)
{
    // Check if the report has at least two levels
    if (report.Count < 2)
    {
        return false;
    }

    bool isIncreasing = report[1] > report[0];
    bool isDecreasing = report[1] < report[0];

    for (int i = 0; i < report.Count - 1; i++)
    {
        int diff = Math.Abs(report[i] - report[i + 1]);

        // Check if the difference is valid (between 1 and 3)
        if (diff < 1 || diff > 3)
        {
            return false; 
        }

        
        if (isIncreasing && report[i + 1] < report[i])
        {
            return false; // Unsafe if it switches to decreasing
        }
        if (isDecreasing && report[i + 1] > report[i])
        {
            return false; // Unsafe if it switches to increasing
        }
    }

    return true; 
}


static bool CanBeMadeSafeByRemovingOneLevel(List<int> report)
{
   
    for (int i = 0; i < report.Count; i++)
    {
        List<int> modifiedReport = new List<int>(report);
        modifiedReport.RemoveAt(i);

        // Check if the modified report is safe
        if (IsSafe(modifiedReport))
        {
            return true; 
        }
    }

    return false; // If no modified report is safe, return false
}
