using System;
using System.IO;

public class PathDebug
{
    public static string GetFullPath()
    {
        // Print the current working directory
        Console.WriteLine("Current Directory: " + Environment.CurrentDirectory);

        // Set your relative path starting from the 'temp' folder
        string relativePath = Path.Combine("temp", "MyText.txt");

        // Combine it with the current working directory
        string fullPath = Path.Combine(Environment.CurrentDirectory, relativePath);

        // Get the directory path
        string? directoryPath = Path.GetDirectoryName(fullPath);

        // Handle the potential null value from GetDirectoryName
        if (directoryPath == null)
        {
            Console.WriteLine("Error: Could not determine the directory path.");
            return string.Empty;  // Exit the program as the path is invalid
        }

        // Check if the directory exists, create it if it doesn't
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Directory does not exist. Creating directory...");
            Directory.CreateDirectory(directoryPath);
        }
        else
        {
            Console.WriteLine("Directory exists.");
        }

        // Check if the file exists
        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File '{fullPath}' does not exist. Creating the file...");
            using (StreamWriter sw = File.CreateText(fullPath))
            {
                sw.WriteLine("This is a test file created by the program.");
            }
        }
        else
        {
            Console.WriteLine($"File '{fullPath}' already exists.");
        }

        // Return the full path so Program.cs can use it
        return fullPath;
    }
}