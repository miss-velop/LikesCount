using System;
using System.Collections.Generic;
namespace LikesCount;
public class Program
{
    public static void Main()
    {
        //List of people who liked
        Console.WriteLine(Likes(new List<string>())); 
        Console.WriteLine(Likes(new List<string> { "Peter" }));
        Console.WriteLine(Likes(new List<string> { "Jacob", "Alex" })); 
        Console.WriteLine(Likes(new List<string> { "Max", "John", "Mark" })); 
        Console.WriteLine(Likes(new List<string> { "Alex", "Jacob", "Mark", "Max" }));

        ////removing duplicates from the file 
        string inputFilePath = "C:\\Users\\palesat\\OneDrive - Flownamix\\Desktop\\Employee File.csv";
        string outputFilePath = "C:\\Users\\palesat\\OneDrive - Flownamix\\Desktop\\Employee File1.csv";
        List<string> lines = File.ReadAllLines(inputFilePath).ToList();
        HashSet<string> uniqueGuids = new HashSet<string>();
        List<string> uniqueLines = new List<string>();
        foreach (var line in lines)
        {
            string[] fields = line.Split(','); 
            string guid = fields[0]; 

            if (!uniqueGuids.Contains(guid))
            {
                uniqueGuids.Add(guid);
                uniqueLines.Add(line);
            }
        }
        File.WriteAllLines(outputFilePath, uniqueLines);
        Console.WriteLine("Duplicates removed successfully.");
    }
    public static string Likes(List<string> names)
    {
        switch (names.Count)
        {
            case 0:
                return "no one likes this";
            case 1:
                return $"{names[0]} likes this";
            case 2:
                return $"{names[0]} and {names[1]} like this";
            case 3:
                return $"{names[0]}, {names[1]} and {names[2]} like this";
            default:
                return $"{names[0]}, {names[1]} and {names.Count - 2} others like this";
        }
    }
}
