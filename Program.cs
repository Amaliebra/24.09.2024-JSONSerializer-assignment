using System.Text.Json;
using System.IO;
using System;

namespace _24._09._2024_JSONSerializer_assignment
{
    public class Program
    {

        public static void Main()
        {
            //string path = Path.Combine(Environment.CurrentDirectory, "24.09.2024-JSONSerializer-assignment", "temp", "MyText.txt");
            string path = @"C:\Users\amali\Desktop\School\24.09.2024-JSONSerializer-assignment\temp\MyText.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("File '{0}' does not exist. Summoning the file..........", path);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("HELLO WORLD");
                    sw.WriteLine("Feed name");
                }
            }

            using (StreamReader sr = File.OpenText(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string? name = Console.ReadLine();
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