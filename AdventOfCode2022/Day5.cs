using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day5 : Day
    {
        public override void Run()
        {
            int numRows = 8;
            int numCols = 9;
            int stride = 4;
            int firstIdx = 1;
            Stack<char>[] stacks = new Stack<char>[numCols];
            for (int i = 0; i < numCols; i++)
            {
                stacks[i] = new Stack<char>();
            }

            // Read containers
            string[] containerLines = containers.Split("\r\n");

            // Add containers to their stacks starting from the last row
            for (int row = numRows - 1; row >= 0; row--)
            {
                for (int col = 0; col < numCols; col++)
                {
                    int charIdx = firstIdx + stride * col;
                    char ch = containerLines[row][charIdx];
                    if (ch != ' ')
                    {
                        stacks[col].Push(ch);

                    }
                }
            }

            // Run instructions
            string[] operationList = operations.Split("\r\n");
            foreach (string line in operationList)
            {
                if (String.IsNullOrEmpty(line)) continue;

                string[] values = line.Split(" ");

                int amount = int.Parse(values[1]);
                int source = int.Parse(values[3]);
                int dest = int.Parse(values[5]);

                for (int i = 0; i < amount; i++)
                {
                    char top = stacks[source - 1].Pop();
                    stacks[dest - 1].Push(top);
                }
            }

            // Display
            Console.WriteLine("Stacks: (left side is top of stack)");
            foreach(var s in stacks)
            {
                foreach (char c in s)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
            }
            

        }
        // First 8 rows
        string containers = "        [M]     [B]             [N]\r\n[T]     [H]     [V] [Q]         [H]\r\n[Q]     [N]     [H] [W] [T]     [Q]\r\n[V]     [P] [F] [Q] [P] [C]     [R]\r\n[C]     [D] [T] [N] [N] [L] [S] [J]\r\n[D] [V] [W] [R] [M] [G] [R] [N] [D]\r\n[S] [F] [Q] [Q] [F] [F] [F] [Z] [S]\r\n[N] [M] [F] [D] [R] [C] [W] [T] [M]";

        string operations = "move 1 from 8 to 7\r\nmove 1 from 2 to 7\r\nmove 6 from 9 to 8\r\nmove 1 from 9 to 1\r\nmove 1 from 9 to 1\r\nmove 3 from 3 to 6\r\nmove 3 from 3 to 9\r\nmove 1 from 9 to 2\r\nmove 5 from 7 to 9\r\nmove 9 from 1 to 6\r\nmove 3 from 4 to 9\r\nmove 2 from 9 to 2\r\nmove 1 from 4 to 2\r\nmove 1 from 3 to 9\r\nmove 8 from 9 to 4\r\nmove 14 from 6 to 7\r\nmove 1 from 3 to 2\r\nmove 5 from 4 to 2\r\nmove 5 from 5 to 7\r\nmove 4 from 2 to 1\r\nmove 2 from 4 to 9\r\nmove 1 from 4 to 3\r\nmove 3 from 5 to 7\r\nmove 1 from 8 to 6\r\nmove 2 from 8 to 7\r\nmove 2 from 1 to 2\r\nmove 1 from 9 to 7\r\nmove 2 from 1 to 3\r\nmove 5 from 6 to 5\r\nmove 4 from 5 to 7\r\nmove 3 from 8 to 4\r\nmove 20 from 7 to 1\r\nmove 11 from 7 to 5\r\nmove 1 from 6 to 9\r\nmove 3 from 9 to 2\r\nmove 12 from 1 to 9\r\nmove 2 from 8 to 3\r\nmove 4 from 2 to 8\r\nmove 8 from 2 to 1\r\nmove 4 from 8 to 9\r\nmove 1 from 2 to 5\r\nmove 12 from 9 to 7\r\nmove 4 from 4 to 9\r\nmove 4 from 9 to 5\r\nmove 13 from 5 to 4\r\nmove 4 from 4 to 7\r\nmove 1 from 7 to 9\r\nmove 2 from 9 to 5\r\nmove 9 from 1 to 2\r\nmove 1 from 8 to 3\r\nmove 5 from 4 to 2\r\nmove 1 from 3 to 6\r\nmove 7 from 2 to 8\r\nmove 6 from 1 to 6\r\nmove 6 from 8 to 7\r\nmove 6 from 2 to 1\r\nmove 3 from 9 to 3\r\nmove 7 from 3 to 7\r\nmove 4 from 4 to 9\r\nmove 1 from 8 to 9\r\nmove 1 from 3 to 9\r\nmove 1 from 2 to 4\r\nmove 1 from 9 to 6\r\nmove 5 from 1 to 9\r\nmove 1 from 4 to 9\r\nmove 2 from 9 to 1\r\nmove 8 from 6 to 7\r\nmove 4 from 9 to 7\r\nmove 2 from 5 to 2\r\nmove 2 from 1 to 9\r\nmove 14 from 7 to 4\r\nmove 22 from 7 to 2\r\nmove 2 from 7 to 4\r\nmove 3 from 7 to 5\r\nmove 9 from 4 to 7\r\nmove 6 from 2 to 4\r\nmove 8 from 4 to 3\r\nmove 14 from 2 to 9\r\nmove 2 from 3 to 9\r\nmove 3 from 2 to 9\r\nmove 4 from 4 to 2\r\nmove 1 from 4 to 5\r\nmove 1 from 1 to 4\r\nmove 5 from 7 to 8\r\nmove 1 from 1 to 3\r\nmove 4 from 5 to 2\r\nmove 6 from 3 to 9\r\nmove 1 from 3 to 4\r\nmove 4 from 8 to 9\r\nmove 2 from 4 to 6\r\nmove 4 from 5 to 3\r\nmove 1 from 7 to 6\r\nmove 1 from 8 to 5\r\nmove 3 from 3 to 1\r\nmove 33 from 9 to 5\r\nmove 5 from 2 to 1\r\nmove 1 from 3 to 5\r\nmove 1 from 7 to 6\r\nmove 18 from 5 to 1\r\nmove 1 from 2 to 8\r\nmove 6 from 5 to 4\r\nmove 1 from 8 to 7\r\nmove 2 from 4 to 1\r\nmove 4 from 1 to 2\r\nmove 19 from 1 to 2\r\nmove 4 from 6 to 8\r\nmove 4 from 1 to 8\r\nmove 14 from 2 to 9\r\nmove 5 from 2 to 4\r\nmove 1 from 8 to 2\r\nmove 8 from 2 to 5\r\nmove 5 from 8 to 4\r\nmove 4 from 9 to 7\r\nmove 1 from 8 to 1\r\nmove 16 from 5 to 4\r\nmove 15 from 4 to 5\r\nmove 1 from 9 to 5\r\nmove 5 from 7 to 6\r\nmove 2 from 7 to 6\r\nmove 1 from 1 to 9\r\nmove 7 from 6 to 7\r\nmove 1 from 8 to 5\r\nmove 1 from 1 to 9\r\nmove 12 from 5 to 7\r\nmove 7 from 5 to 9\r\nmove 12 from 7 to 2\r\nmove 1 from 7 to 4\r\nmove 7 from 4 to 7\r\nmove 2 from 9 to 4\r\nmove 5 from 4 to 9\r\nmove 8 from 2 to 3\r\nmove 4 from 2 to 4\r\nmove 9 from 4 to 8\r\nmove 6 from 3 to 5\r\nmove 8 from 7 to 3\r\nmove 1 from 4 to 3\r\nmove 7 from 8 to 9\r\nmove 4 from 5 to 4\r\nmove 6 from 3 to 1\r\nmove 4 from 3 to 4\r\nmove 1 from 3 to 6\r\nmove 6 from 4 to 9\r\nmove 1 from 6 to 5\r\nmove 17 from 9 to 4\r\nmove 3 from 7 to 3\r\nmove 1 from 7 to 9\r\nmove 2 from 5 to 3\r\nmove 2 from 1 to 3\r\nmove 2 from 8 to 9\r\nmove 1 from 5 to 1\r\nmove 14 from 4 to 5\r\nmove 2 from 3 to 2\r\nmove 1 from 7 to 6\r\nmove 10 from 9 to 4\r\nmove 12 from 9 to 4\r\nmove 9 from 4 to 5\r\nmove 1 from 2 to 9\r\nmove 13 from 5 to 9\r\nmove 2 from 5 to 1\r\nmove 1 from 2 to 9\r\nmove 3 from 4 to 2\r\nmove 12 from 4 to 7\r\nmove 8 from 5 to 7\r\nmove 1 from 1 to 9\r\nmove 1 from 6 to 4\r\nmove 1 from 5 to 4\r\nmove 1 from 4 to 8\r\nmove 5 from 3 to 4\r\nmove 10 from 9 to 6\r\nmove 3 from 6 to 2\r\nmove 7 from 6 to 5\r\nmove 6 from 5 to 4\r\nmove 1 from 8 to 5\r\nmove 1 from 1 to 4\r\nmove 2 from 7 to 2\r\nmove 5 from 4 to 9\r\nmove 2 from 5 to 8\r\nmove 1 from 1 to 3\r\nmove 2 from 1 to 7\r\nmove 6 from 7 to 9\r\nmove 9 from 9 to 8\r\nmove 1 from 1 to 3\r\nmove 4 from 2 to 7\r\nmove 11 from 7 to 3\r\nmove 11 from 8 to 6\r\nmove 7 from 3 to 1\r\nmove 4 from 7 to 2\r\nmove 3 from 2 to 9\r\nmove 8 from 1 to 5\r\nmove 2 from 7 to 5\r\nmove 2 from 2 to 9\r\nmove 2 from 3 to 9\r\nmove 11 from 4 to 7\r\nmove 7 from 9 to 5\r\nmove 6 from 6 to 5\r\nmove 2 from 2 to 9\r\nmove 1 from 2 to 3\r\nmove 6 from 9 to 4\r\nmove 3 from 9 to 1\r\nmove 4 from 3 to 5\r\nmove 6 from 7 to 1\r\nmove 2 from 6 to 3\r\nmove 2 from 9 to 2\r\nmove 3 from 3 to 2\r\nmove 3 from 6 to 8\r\nmove 2 from 7 to 5\r\nmove 20 from 5 to 6\r\nmove 8 from 5 to 1\r\nmove 1 from 5 to 9\r\nmove 2 from 8 to 4\r\nmove 1 from 8 to 7\r\nmove 16 from 1 to 8\r\nmove 8 from 8 to 9\r\nmove 4 from 2 to 4\r\nmove 1 from 1 to 5\r\nmove 1 from 5 to 4\r\nmove 3 from 8 to 4\r\nmove 14 from 4 to 6\r\nmove 5 from 8 to 7\r\nmove 6 from 7 to 8\r\nmove 29 from 6 to 2\r\nmove 3 from 9 to 8\r\nmove 21 from 2 to 3\r\nmove 1 from 8 to 3\r\nmove 6 from 9 to 4\r\nmove 8 from 3 to 5\r\nmove 7 from 8 to 4\r\nmove 7 from 3 to 9\r\nmove 3 from 7 to 2\r\nmove 12 from 4 to 8\r\nmove 2 from 3 to 1\r\nmove 2 from 9 to 1\r\nmove 1 from 6 to 7\r\nmove 1 from 7 to 6\r\nmove 1 from 6 to 3\r\nmove 3 from 1 to 8\r\nmove 2 from 4 to 1\r\nmove 4 from 6 to 1\r\nmove 5 from 2 to 7\r\nmove 1 from 1 to 2\r\nmove 5 from 1 to 2\r\nmove 2 from 8 to 1\r\nmove 1 from 4 to 5\r\nmove 9 from 8 to 4\r\nmove 3 from 7 to 9\r\nmove 7 from 5 to 7\r\nmove 2 from 5 to 9\r\nmove 4 from 9 to 2\r\nmove 3 from 3 to 2\r\nmove 5 from 2 to 7\r\nmove 2 from 8 to 2\r\nmove 2 from 7 to 3\r\nmove 1 from 8 to 6\r\nmove 2 from 1 to 2\r\nmove 1 from 6 to 7\r\nmove 1 from 8 to 1\r\nmove 12 from 7 to 1\r\nmove 5 from 2 to 7\r\nmove 7 from 4 to 2\r\nmove 2 from 4 to 1\r\nmove 5 from 3 to 8\r\nmove 7 from 1 to 9\r\nmove 4 from 7 to 1\r\nmove 7 from 1 to 5\r\nmove 12 from 9 to 2\r\nmove 27 from 2 to 4\r\nmove 3 from 8 to 9\r\nmove 6 from 2 to 5\r\nmove 6 from 1 to 8\r\nmove 1 from 7 to 6\r\nmove 9 from 5 to 2\r\nmove 3 from 9 to 2\r\nmove 13 from 4 to 5\r\nmove 10 from 2 to 7\r\nmove 1 from 9 to 8\r\nmove 11 from 5 to 7\r\nmove 1 from 8 to 7\r\nmove 1 from 2 to 6\r\nmove 13 from 4 to 3\r\nmove 23 from 7 to 4\r\nmove 1 from 6 to 9\r\nmove 1 from 2 to 4\r\nmove 7 from 3 to 5\r\nmove 1 from 9 to 8\r\nmove 19 from 4 to 1\r\nmove 2 from 4 to 1\r\nmove 1 from 7 to 6\r\nmove 1 from 4 to 5\r\nmove 1 from 5 to 7\r\nmove 11 from 5 to 1\r\nmove 2 from 5 to 4\r\nmove 2 from 6 to 9\r\nmove 3 from 8 to 2\r\nmove 2 from 8 to 1\r\nmove 3 from 2 to 1\r\nmove 1 from 9 to 5\r\nmove 6 from 1 to 3\r\nmove 1 from 9 to 7\r\nmove 2 from 7 to 5\r\nmove 2 from 8 to 6\r\nmove 1 from 3 to 2\r\nmove 2 from 8 to 5\r\nmove 1 from 2 to 1\r\nmove 3 from 4 to 1\r\nmove 3 from 5 to 1\r\nmove 2 from 5 to 1\r\nmove 2 from 6 to 9\r\nmove 1 from 9 to 6\r\nmove 1 from 4 to 5\r\nmove 1 from 9 to 8\r\nmove 1 from 8 to 6\r\nmove 8 from 1 to 6\r\nmove 7 from 1 to 8\r\nmove 9 from 1 to 6\r\nmove 1 from 5 to 3\r\nmove 3 from 8 to 4\r\nmove 11 from 3 to 4\r\nmove 1 from 3 to 6\r\nmove 10 from 6 to 8\r\nmove 13 from 1 to 6\r\nmove 3 from 4 to 5\r\nmove 7 from 8 to 6\r\nmove 3 from 8 to 5\r\nmove 6 from 5 to 3\r\nmove 22 from 6 to 9\r\nmove 4 from 3 to 6\r\nmove 4 from 9 to 5\r\nmove 1 from 1 to 5\r\nmove 2 from 3 to 4\r\nmove 2 from 1 to 5\r\nmove 1 from 9 to 2\r\nmove 5 from 8 to 3\r\nmove 2 from 9 to 2\r\nmove 11 from 6 to 9\r\nmove 3 from 2 to 7\r\nmove 1 from 6 to 7\r\nmove 12 from 9 to 8\r\nmove 4 from 7 to 1\r\nmove 12 from 4 to 8\r\nmove 2 from 4 to 7\r\nmove 1 from 1 to 8\r\nmove 1 from 5 to 1\r\nmove 19 from 8 to 4\r\nmove 4 from 5 to 1\r\nmove 1 from 7 to 4\r\nmove 1 from 7 to 1\r\nmove 3 from 3 to 4\r\nmove 2 from 8 to 4\r\nmove 1 from 5 to 7\r\nmove 1 from 7 to 9\r\nmove 8 from 1 to 8\r\nmove 1 from 1 to 4\r\nmove 1 from 3 to 9\r\nmove 1 from 3 to 5\r\nmove 1 from 5 to 2\r\nmove 7 from 8 to 7\r\nmove 16 from 4 to 7\r\nmove 1 from 7 to 4\r\nmove 3 from 8 to 2\r\nmove 14 from 7 to 4\r\nmove 1 from 5 to 8\r\nmove 5 from 7 to 5\r\nmove 16 from 4 to 5\r\nmove 3 from 5 to 4\r\nmove 3 from 2 to 1\r\nmove 1 from 7 to 9\r\nmove 11 from 4 to 2\r\nmove 3 from 8 to 6\r\nmove 2 from 1 to 8\r\nmove 1 from 4 to 9\r\nmove 18 from 5 to 1\r\nmove 1 from 8 to 7\r\nmove 3 from 7 to 9\r\nmove 18 from 9 to 3\r\nmove 3 from 6 to 9\r\nmove 7 from 1 to 6\r\nmove 1 from 8 to 4\r\nmove 1 from 4 to 9\r\nmove 3 from 6 to 4\r\nmove 5 from 9 to 2\r\nmove 2 from 4 to 7\r\nmove 7 from 2 to 8\r\nmove 1 from 7 to 3\r\nmove 2 from 6 to 8\r\nmove 1 from 9 to 5\r\nmove 1 from 6 to 8\r\nmove 1 from 4 to 8\r\nmove 1 from 5 to 3\r\nmove 1 from 7 to 5\r\nmove 8 from 8 to 7\r\nmove 10 from 2 to 6\r\nmove 1 from 9 to 3\r\nmove 6 from 6 to 2\r\nmove 5 from 6 to 2\r\nmove 7 from 2 to 7\r\nmove 12 from 1 to 6\r\nmove 2 from 2 to 1\r\nmove 1 from 2 to 5\r\nmove 4 from 7 to 6\r\nmove 12 from 3 to 1\r\nmove 2 from 7 to 2\r\nmove 9 from 3 to 8\r\nmove 1 from 2 to 6\r\nmove 1 from 5 to 4\r\nmove 9 from 6 to 5\r\nmove 1 from 7 to 6\r\nmove 1 from 4 to 9\r\nmove 9 from 6 to 7\r\nmove 7 from 8 to 3\r\nmove 6 from 3 to 1\r\nmove 4 from 8 to 3\r\nmove 5 from 3 to 1\r\nmove 1 from 9 to 8\r\nmove 2 from 8 to 9\r\nmove 5 from 5 to 7\r\nmove 14 from 7 to 8\r\nmove 1 from 9 to 4\r\nmove 2 from 2 to 1\r\nmove 3 from 5 to 3\r\nmove 2 from 3 to 1\r\nmove 1 from 4 to 6\r\nmove 6 from 8 to 6\r\nmove 6 from 8 to 3\r\nmove 3 from 6 to 1\r\nmove 2 from 8 to 9\r\nmove 19 from 1 to 6\r\nmove 3 from 9 to 3\r\nmove 6 from 3 to 4\r\nmove 6 from 6 to 2\r\nmove 4 from 3 to 9\r\nmove 1 from 7 to 9\r\nmove 2 from 5 to 7\r\nmove 5 from 9 to 6\r\nmove 6 from 7 to 2\r\nmove 11 from 2 to 5\r\nmove 2 from 7 to 4\r\nmove 4 from 4 to 3\r\nmove 2 from 4 to 8\r\nmove 12 from 1 to 2\r\nmove 1 from 8 to 2\r\nmove 8 from 5 to 7\r\nmove 2 from 4 to 9\r\nmove 2 from 7 to 1\r\nmove 4 from 2 to 3\r\nmove 1 from 8 to 6\r\nmove 1 from 1 to 5\r\nmove 2 from 9 to 1\r\nmove 2 from 7 to 3\r\nmove 2 from 5 to 2\r\nmove 1 from 5 to 7\r\nmove 2 from 7 to 8\r\nmove 1 from 5 to 7\r\nmove 5 from 3 to 4\r\nmove 3 from 1 to 7\r\nmove 1 from 2 to 4\r\nmove 15 from 6 to 1\r\nmove 4 from 4 to 1\r\nmove 4 from 2 to 3\r\nmove 8 from 3 to 2\r\nmove 5 from 2 to 4\r\nmove 1 from 8 to 6\r\nmove 1 from 8 to 9\r\nmove 1 from 3 to 1\r\nmove 3 from 7 to 3\r\nmove 5 from 7 to 6\r\nmove 4 from 2 to 9\r\nmove 6 from 2 to 6\r\nmove 4 from 9 to 6\r\nmove 12 from 1 to 5\r\nmove 6 from 4 to 1\r\nmove 1 from 3 to 6\r\nmove 4 from 5 to 8\r\nmove 7 from 5 to 3\r\nmove 3 from 8 to 2\r\nmove 1 from 2 to 3\r\nmove 1 from 9 to 5\r\nmove 1 from 4 to 5\r\nmove 1 from 8 to 5\r\nmove 8 from 6 to 9\r\nmove 10 from 1 to 4\r\nmove 3 from 6 to 1\r\nmove 9 from 3 to 6\r\nmove 1 from 3 to 8\r\nmove 1 from 2 to 4\r\nmove 6 from 9 to 1\r\nmove 1 from 1 to 4\r\nmove 10 from 1 to 6\r\nmove 1 from 8 to 6\r\nmove 13 from 6 to 7\r\nmove 1 from 2 to 1\r\nmove 1 from 9 to 6\r\nmove 9 from 7 to 5\r\nmove 1 from 9 to 4\r\nmove 3 from 7 to 1\r\nmove 3 from 5 to 6\r\nmove 10 from 4 to 7\r\nmove 5 from 6 to 5\r\nmove 3 from 4 to 5\r\nmove 13 from 6 to 9\r\nmove 7 from 5 to 3\r\nmove 6 from 3 to 2\r\nmove 5 from 6 to 4\r\nmove 4 from 2 to 8";
    }
}
