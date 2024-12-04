// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Tracing;
using System.Text;

Console.WriteLine("Hello, World!");

// Initialize two lists to store the columns
List<int> column1 = new List<int>();
List<int> column2 = new List<int>();
List<int> distanceApart = new List<int>();
List<int> similarityList = new List<int>();
var count = 0;
var similaritySum = 0;


string fileloc = @"C:\Users\selvabh\source\experimentation\AdventOfCode2024\AdventOfCode2024\ConsoleApp1\input\input_data.txt";

using (StreamReader read = new StreamReader(fileloc))
{
    
    string line;
    var inputcounter = 0;
    while ((line = read.ReadLine()) != null)
    {
        
        string[] parts = line.Split(new string[] { "   " }, StringSplitOptions.None);        
        // Add to respective lists
        var num1 = int.Parse(parts[0]);
        var num2 = int.Parse(parts[1]); 
        column1.Add(num1);
        column2.Add(num2);
        inputcounter++;
    }
    Console.WriteLine(inputcounter);
}

//sort arrays
column1.Sort();
column2.Sort();

Console.WriteLine(column1.Count);
Console.WriteLine(column2.Count);

//find difference and add into new array
for (int i = 0; i < column1.Count; i++)
{
    var difference = Math.Abs(column1[i] - column2[i]);
    distanceApart.Add(difference);
}

//compute sum of array three
for (int i = 0;i < distanceApart.Count; i++)
{
    count = count + distanceApart[i];
}

Console.WriteLine("Difference Score: ");
Console.WriteLine(count);
//display sum


//----------Part 2: Find SImilarty Score

for (int i = 0; i < column1.Count; i++)
{
    int occuranceCounter = column2.FindAll(n => n == column1[i]).Count();    
    similarityList.Add(column1[i]*occuranceCounter);
}


for (int i = 0; i < similarityList.Count; i++)
{
    similaritySum = similaritySum + similarityList[i];
}

Console.WriteLine("Similarity Score: ");
Console.WriteLine(similaritySum);
