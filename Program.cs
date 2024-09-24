using System.Text.Json;
using System.IO;

namespace _24._09._2024_JSONSerializer_assignment
{
    internal class Program
    {
        public static void Main()
        {
            string path = @"C:\Users\amali\Desktop\School\24.09.2024-JSONSerializer-assignment\temp";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("HELLO WORLD")
                }
            }
        }
    }
}