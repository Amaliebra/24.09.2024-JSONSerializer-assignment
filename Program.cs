using System.Text.Json;
using System.IO;
using System;

namespace _24._09._2024_JSONSerializer_assignment
{
    public class Program
    {

        public static void Main()
        {
            //string relativePath = Path.Combine("24.09.2024-JSONSerializer-assignment", "temp", "MyText.txt");
            //string fullPath = Path.Combine(Environment.CurrentDirectory, relativePath);
            //string path = @"C:\Users\amali\Desktop\School\24.09.2024-JSONSerializer-assignment\temp\MyText.txt";
            string fullPath = PathDebug.GetFullPath();

            // Check if the fullPath was successfully retrieved
            if (!string.IsNullOrEmpty(fullPath))
            {
                Console.WriteLine("Using the file path: " + fullPath);
            }
            else
            {
                Console.WriteLine("Failed to retrieve the full path.");
            }

            if (!File.Exists(fullPath))
            {
                Console.WriteLine("File '{0}' does not exist. Summoning the file..........", fullPath);
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine("HELLO WORLD");
                    sw.WriteLine("Feed name");
                }
            }

            Console.WriteLine("Enter name:");
            string? name = Console.ReadLine();

            using (StreamWriter sw = File.AppendText(fullPath))
            {
                sw.WriteLine($"Name: {name}");
            }

            using (StreamReader sr = File.OpenText(fullPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            var serializeWeather = new SerializeWeather
            {
                Date = DateTime.Now,
                TemperatureCelsius = 25,
                Summary = "Good temperature"
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(serializeWeather, options);
            Console.WriteLine(jsonString);
        }
    }
}