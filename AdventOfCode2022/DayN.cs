namespace AdventOfCode2022
{
    internal class DayN : Day
    {
        // Place a file in input subfolder
        readonly string SOURCE_DIR = "../../../input/";

        public override void Run()
        {
            string inputPath = "day8.txt";
            string[] lines = ReadInput(SOURCE_DIR + inputPath);
            int answer = 0;

            // Code goes here



            Console.WriteLine("The answer is {0}", answer);
        }

        static string[] ReadInput(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
