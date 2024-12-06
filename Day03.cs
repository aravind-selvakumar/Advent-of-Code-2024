class Program
{
    static void Main()
    {
        string fileloc = @"C:\source\experimentation\AdventOfCode2024\AdventOfCode2024\Day03\Day03InputData.txt";

        var totalAnswer = 0;
        bool isEnabled = true;  // mul() is enabled by default
        string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";  // Pattern to match mul(X,Y)
        string dontToDoPattern = @"don't\(\)(.*?)(?=do\(\))"; // Pattern to remove 'don't()' to 'do()' sections

        using (StreamReader read = new StreamReader(fileloc))
        {
            string line;

            while ((line = read.ReadLine()) != null)
            {
                // Step 1: Remove everything between 'don't()' and the next 'do()'
                line = Regex.Replace(line, dontToDoPattern, "");

                // Step 2: Process any 'do()' or 'don't()' commands
                if (line.Contains("do()"))
                {
                    isEnabled = true; // Enable mul() instructions
                    Console.WriteLine("do() encountered: Enabling mul()");
                }
                else if (line.Contains("don't()"))
                {
                    isEnabled = false; // Disable mul() instructions
                    Console.WriteLine("don't() encountered: Disabling mul()");
                }

                // Step 3: Process mul(X,Y) if mul is enabled
                if (isEnabled)
                {
                    // Match all valid mul(X,Y) instructions
                    MatchCollection matches = Regex.Matches(line, mulPattern);

                    foreach (Match match in matches)
                    {
                        // Extract the numbers from the mul() instruction
                        int num1 = int.Parse(match.Groups[1].Value);
                        int num2 = int.Parse(match.Groups[2].Value);
                        int result = num1 * num2;
                        totalAnswer += result;
                        Console.WriteLine($"mul({num1},{num2}) = {result}");
                    }
                }
            }

            // Print the final accumulated answer
            Console.WriteLine($"Total Answer: {totalAnswer}");
        }
    }
}
