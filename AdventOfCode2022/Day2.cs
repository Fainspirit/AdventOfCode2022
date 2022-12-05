using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day2 : Day
    {
        enum RPS
        {
            None, Rock, Paper, Scissors, None2 // Hack to deal with calc
        }

        int GetScore (RPS me, RPS them)
        {
            int score = 0;

            switch (me) {
                case RPS.Rock:
                    {
                        score += 1;
                        if (them == RPS.Rock) { score += 3; }
                        if (them == RPS.Scissors) { score += 6; }
                        break;
                    }
                case RPS.Paper:
                    {
                        score += 2;
                        if (them == RPS.Paper) { score += 3; }
                        if (them == RPS.Rock) { score += 6; }
                        break;
                    }
                case RPS.Scissors:
                    {
                        score += 3;
                        if (them == RPS.Scissors) { score += 3; }
                        if (them == RPS.Paper) { score += 6; }
                        break;
                    }
                case RPS.None:
                    Console.WriteLine("You played nothing aaaa");
                    break;
            }
            return score;
        }

        public override void Run()
        {
            string[] lines = input.Split("\r\n");
            int totalScore = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                // parse RPS
                char me = line[2];
                char them = line[0];
                RPS myShape = RPS.None;
                RPS theirShape = RPS.None;

                // Ver. 1
                /*
                switch (me)
                {
                    case 'X': myShape = RPS.Rock; break;
                    case 'Y': myShape = RPS.Paper; break;
                    case 'Z': myShape = RPS.Scissors; break;
                }
                */
                switch (them)
                {
                    case 'A': theirShape = RPS.Rock; break;
                    case 'B': theirShape = RPS.Paper; break;
                    case 'C': theirShape = RPS.Scissors; break;
                }
                // Ver 2.
                switch (me)
                {
                    case 'X': // lose
                        {
                            // 1 before in cycle
                            myShape = theirShape - 1;
                            if (myShape == RPS.None) myShape = RPS.Scissors;
                            break;
                        }
                    case 'Y': // draw
                        {
                            // same
                            myShape = theirShape;
                            break;
                        }
                    case 'Z': // win
                        {
                            // 1 higher in cycle
                            myShape = theirShape + 1;
                            if (myShape == RPS.None2) myShape = RPS.Rock;
                            break;
                        }

                }
                totalScore += GetScore(myShape, theirShape);
                // Get and add score
            }

            Console.WriteLine("Your total score is {0}", totalScore);
           
        }

        string input = "B Y\r\nA Z\r\nA Z\r\nB Y\r\nA Z\r\nB X\r\nA X\r\nA Z\r\nC X\r\nA Z\r\nC Y\r\nB Y\r\nC X\r\nC Y\r\nB Y\r\nC Y\r\nC Y\r\nC Z\r\nA Z\r\nB Y\r\nB Y\r\nA Z\r\nB Z\r\nC Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nB Z\r\nC Z\r\nC Z\r\nB Z\r\nC Z\r\nC Y\r\nB Y\r\nC Z\r\nC X\r\nB Y\r\nC Y\r\nC Y\r\nC Z\r\nC Y\r\nA Y\r\nA Z\r\nA Z\r\nA Z\r\nA X\r\nA Z\r\nA Z\r\nC X\r\nC Z\r\nC Y\r\nC Y\r\nB Z\r\nC Y\r\nC Y\r\nC X\r\nC Z\r\nC Y\r\nA Z\r\nC Y\r\nA Y\r\nA Z\r\nB X\r\nA Y\r\nC Y\r\nC Z\r\nA Z\r\nB X\r\nC Z\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nA Z\r\nC Y\r\nA Z\r\nA X\r\nA Y\r\nB Y\r\nA X\r\nA Y\r\nB X\r\nC Z\r\nC Y\r\nC Z\r\nA Y\r\nA X\r\nC Y\r\nB Z\r\nA Z\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nB Y\r\nA Z\r\nB Y\r\nB X\r\nA Z\r\nC Y\r\nC Y\r\nA Y\r\nA Z\r\nA Z\r\nB Y\r\nA Z\r\nB Y\r\nC Y\r\nA Z\r\nB Y\r\nC Z\r\nB Y\r\nA Z\r\nC Y\r\nB Y\r\nA Y\r\nB X\r\nA Z\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nA Z\r\nC X\r\nC Y\r\nC X\r\nA Z\r\nC Y\r\nC Y\r\nC Z\r\nC Z\r\nA Z\r\nC X\r\nA Y\r\nA Z\r\nC Y\r\nB Y\r\nA X\r\nB Y\r\nA Z\r\nC Z\r\nA Z\r\nC Y\r\nB X\r\nC X\r\nA Z\r\nC Z\r\nA Z\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nB Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nA Y\r\nA Z\r\nA Z\r\nC Y\r\nC Z\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nB X\r\nA Z\r\nC Y\r\nB Z\r\nC Z\r\nA Z\r\nA Z\r\nA Z\r\nA Z\r\nA Y\r\nC Y\r\nC Y\r\nC Z\r\nC Y\r\nA Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nA Z\r\nB Z\r\nA Z\r\nC Y\r\nB Y\r\nA Z\r\nB Y\r\nA Z\r\nC Z\r\nB Y\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nA Z\r\nC Z\r\nA Y\r\nC Y\r\nB X\r\nA X\r\nB Y\r\nC Y\r\nA Z\r\nA Z\r\nA X\r\nA Z\r\nB Y\r\nA Z\r\nC Y\r\nB Y\r\nA Z\r\nA Z\r\nB Z\r\nA Z\r\nB Y\r\nC Z\r\nC Y\r\nB X\r\nC Z\r\nC X\r\nC Y\r\nA Y\r\nA Z\r\nA X\r\nB Y\r\nA Y\r\nC Y\r\nC Y\r\nA Z\r\nA Z\r\nA Z\r\nC Z\r\nC Y\r\nB Y\r\nA Z\r\nA Z\r\nA Y\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nA Z\r\nC X\r\nA Z\r\nB Z\r\nC Z\r\nA Z\r\nB Y\r\nA Z\r\nB Y\r\nC X\r\nC Y\r\nC Z\r\nC Z\r\nC X\r\nA Z\r\nC Y\r\nA Z\r\nC X\r\nA Z\r\nB Y\r\nA X\r\nB Z\r\nA Z\r\nA Z\r\nC X\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nA X\r\nC Z\r\nA X\r\nA X\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nA X\r\nB Y\r\nB Z\r\nB Y\r\nA Z\r\nC Z\r\nA Y\r\nC Y\r\nA Z\r\nA Y\r\nA Z\r\nC Z\r\nA X\r\nA Z\r\nA X\r\nA Z\r\nB Y\r\nA X\r\nA Z\r\nC Y\r\nA Z\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nA Z\r\nB X\r\nC Y\r\nB Z\r\nA Z\r\nA Z\r\nA Z\r\nB Y\r\nA Z\r\nC X\r\nC Y\r\nB Y\r\nC Y\r\nA Z\r\nC Y\r\nC Z\r\nA Z\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nA Z\r\nA Z\r\nB Y\r\nA Z\r\nC Y\r\nC Z\r\nC Y\r\nB Y\r\nB Z\r\nC Y\r\nB Y\r\nA Z\r\nB Y\r\nB X\r\nA Z\r\nA X\r\nC Y\r\nA X\r\nC Z\r\nC Z\r\nC X\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nC Z\r\nB X\r\nC Y\r\nA Y\r\nC Y\r\nA Z\r\nC Z\r\nA Z\r\nC Y\r\nC Y\r\nB Y\r\nC Y\r\nC Y\r\nA Z\r\nA Z\r\nA Z\r\nA Z\r\nC Y\r\nA X\r\nA X\r\nA Z\r\nA Z\r\nB Y\r\nA Y\r\nA Z\r\nA Y\r\nA Z\r\nC Z\r\nA Y\r\nB Y\r\nA Y\r\nA Z\r\nC Z\r\nB X\r\nA Z\r\nC X\r\nC Z\r\nC Y\r\nA Z\r\nA Z\r\nA Z\r\nA Y\r\nA Y\r\nC Y\r\nA Y\r\nB X\r\nC Y\r\nA X\r\nC Y\r\nA Z\r\nB Z\r\nC Z\r\nA Z\r\nC Y\r\nC Y\r\nB Y\r\nC Y\r\nB Y\r\nA Y\r\nC X\r\nA Y\r\nC Y\r\nA Y\r\nC X\r\nC Y\r\nC Y\r\nC Y\r\nC Z\r\nA X\r\nA Z\r\nC Z\r\nA Z\r\nC Z\r\nA Z\r\nC Y\r\nC Z\r\nC Y\r\nC Y\r\nC Y\r\nA X\r\nA Z\r\nC X\r\nC Y\r\nA Z\r\nA Z\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nA Z\r\nB Y\r\nC Y\r\nA Z\r\nC Y\r\nA Y\r\nC Y\r\nA X\r\nA Z\r\nA Y\r\nA Z\r\nA Z\r\nB X\r\nB Y\r\nA Z\r\nA Z\r\nB Y\r\nC Z\r\nA Z\r\nA Y\r\nA Z\r\nB Z\r\nB Y\r\nA Y\r\nC X\r\nC Z\r\nC Y\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nC Z\r\nC X\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nA X\r\nA Z\r\nB Y\r\nC Z\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nA Y\r\nA Z\r\nA Z\r\nA Z\r\nA Z\r\nC Z\r\nA Y\r\nA Y\r\nB Z\r\nA Y\r\nC Y\r\nB X\r\nB X\r\nB Y\r\nC Y\r\nB X\r\nC Y\r\nA Z\r\nA Z\r\nA Y\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nA Z\r\nC Y\r\nA Z\r\nA Z\r\nB Z\r\nC Y\r\nB Y\r\nB Z\r\nA Y\r\nC Y\r\nB Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nA Z\r\nA X\r\nA Z\r\nB Y\r\nC Y\r\nC Y\r\nA Z\r\nC Z\r\nA Z\r\nB Y\r\nC Y\r\nC Z\r\nB X\r\nB Y\r\nA Z\r\nA Z\r\nA Z\r\nC Z\r\nC X\r\nB Y\r\nA Y\r\nA Y\r\nA Z\r\nA Y\r\nA Z\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nA Z\r\nC Z\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nB Y\r\nC Z\r\nA Y\r\nA Z\r\nB Y\r\nB Z\r\nA Z\r\nA Y\r\nA Z\r\nB X\r\nA Z\r\nA Y\r\nC Y\r\nC Y\r\nB X\r\nA Z\r\nB Z\r\nC Y\r\nC Z\r\nC Y\r\nA X\r\nA X\r\nB X\r\nA Z\r\nC Y\r\nC Y\r\nB X\r\nB Z\r\nA Z\r\nC Y\r\nB Y\r\nB Y\r\nC Z\r\nC Y\r\nB Z\r\nA Z\r\nA Z\r\nC X\r\nA Z\r\nA Z\r\nA Z\r\nA Y\r\nB Z\r\nB Z\r\nA Y\r\nA Y\r\nC Y\r\nA Z\r\nA Z\r\nA Z\r\nB Y\r\nC X\r\nB Y\r\nA Y\r\nC Y\r\nC Z\r\nC Y\r\nC X\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nC Y\r\nA X\r\nC Z\r\nB Y\r\nA Y\r\nA Z\r\nB Y\r\nA Z\r\nB Y\r\nA Z\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nC Y\r\nA Z\r\nA Z\r\nB X\r\nC Y\r\nA Y\r\nA Y\r\nB X\r\nC Z\r\nC Y\r\nB Y\r\nC Y\r\nC Z\r\nA Z\r\nC Y\r\nA Y\r\nA Z\r\nA Z\r\nB X\r\nC Y\r\nC Z\r\nC Y\r\nC Z\r\nA Z\r\nC Y\r\nC Z\r\nA Y\r\nC Y\r\nC X\r\nC Y\r\nC Y\r\nC Y\r\nA X\r\nA Y\r\nC Z\r\nB Y\r\nA Z\r\nC Z\r\nC Y\r\nA Z\r\nB Y\r\nC Y\r\nA Z\r\nA Z\r\nA Z\r\nC Z\r\nA Y\r\nA Z\r\nC Y\r\nA Z\r\nC Z\r\nA Z\r\nA Z\r\nC Z\r\nA X\r\nC Y\r\nB Y\r\nA Z\r\nA X\r\nA Z\r\nA Z\r\nB Y\r\nA Z\r\nC Y\r\nC Z\r\nC Y\r\nC Y\r\nB Z\r\nC X\r\nA Z\r\nC Z\r\nC Z\r\nA Y\r\nA Y\r\nC Z\r\nA Y\r\nA Y\r\nB X\r\nA Z\r\nA Z\r\nA Z\r\nB X\r\nC Y\r\nA Y\r\nA Z\r\nC Y\r\nC Y\r\nC X\r\nC Z\r\nA Z\r\nB Y\r\nB Z\r\nA Y\r\nC Y\r\nC Y\r\nB Y\r\nA Z\r\nC Y\r\nA Z\r\nA X\r\nC Z\r\nC Z\r\nA Z\r\nC Y\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nC Z\r\nC Y\r\nC Y\r\nC Y\r\nA Z\r\nB Z\r\nA Z\r\nB X\r\nA X\r\nC Y\r\nC Y\r\nA Y\r\nA Z\r\nB Y\r\nA Z\r\nC Y\r\nB Y\r\nB X\r\nB Y\r\nA Z\r\nC Z\r\nC Y\r\nB Y\r\nC Y\r\nC Y\r\nC Z\r\nC X\r\nC Y\r\nA Z\r\nA Y\r\nA Z\r\nC Y\r\nB Z\r\nC Z\r\nA X\r\nC Y\r\nA Y\r\nC Y\r\nA Z\r\nA Y\r\nB Y\r\nA Z\r\nA X\r\nA X\r\nB Y\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Z\r\nC Y\r\nA Z\r\nA Z\r\nB Z\r\nB X\r\nA Z\r\nC Z\r\nA Z\r\nC Y\r\nC Y\r\nC Z\r\nC Y\r\nA Y\r\nC Y\r\nA Y\r\nB Y\r\nB Y\r\nB Y\r\nA Z\r\nA X\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nA Z\r\nA Y\r\nB Y\r\nA Y\r\nA Y\r\nC Y\r\nA Z\r\nC Z\r\nA Z\r\nC X\r\nA Z\r\nA Y\r\nC Z\r\nA Z\r\nA Z\r\nC Y\r\nB Y\r\nC Y\r\nA Z\r\nC Z\r\nB Y\r\nB Y\r\nA Z\r\nA Z\r\nA X\r\nA Z\r\nC Z\r\nC Y\r\nA Z\r\nA Z\r\nA X\r\nA Z\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nA Y\r\nB X\r\nC Y\r\nB Y\r\nB Y\r\nC X\r\nA Z\r\nA Z\r\nC Y\r\nC Y\r\nC Z\r\nA X\r\nA Z\r\nB X\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nC Z\r\nA Y\r\nB Y\r\nC Y\r\nC X\r\nA Z\r\nA Y\r\nA Y\r\nC Y\r\nA Z\r\nB Z\r\nA Y\r\nC Y\r\nA Z\r\nC Y\r\nC X\r\nA Z\r\nB X\r\nB Y\r\nC X\r\nA Y\r\nA Y\r\nA Z\r\nA Z\r\nB X\r\nA Z\r\nA Y\r\nA Z\r\nC Y\r\nA X\r\nC Y\r\nA Z\r\nB Y\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nA X\r\nC Z\r\nC Z\r\nB Y\r\nA Y\r\nA Y\r\nC Y\r\nA X\r\nA Z\r\nA X\r\nB Y\r\nA Z\r\nA Z\r\nA Y\r\nA X\r\nC Y\r\nB X\r\nA Z\r\nA Z\r\nA Z\r\nA Z\r\nC Z\r\nA Z\r\nA Z\r\nA Y\r\nB Y\r\nA X\r\nA Y\r\nC Y\r\nA X\r\nB Y\r\nA Z\r\nA Z\r\nC Y\r\nB Y\r\nB Y\r\nA Z\r\nC Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nA Z\r\nB Y\r\nB Y\r\nB Y\r\nA X\r\nA Z\r\nA Z\r\nA Z\r\nA Y\r\nA Z\r\nA Z\r\nA Z\r\nB Y\r\nA X\r\nC Z\r\nA Z\r\nA X\r\nC Z\r\nA Z\r\nA Y\r\nC Y\r\nC Z\r\nA X\r\nC Z\r\nA Y\r\nB Y\r\nC Z\r\nA Z\r\nC Y\r\nB Y\r\nB Y\r\nB Z\r\nC X\r\nA Z\r\nB Y\r\nC Y\r\nC Y\r\nC X\r\nA Z\r\nA Z\r\nA Y\r\nC Y\r\nB X\r\nB X\r\nA Y\r\nA Z\r\nC Y\r\nC X\r\nA Y\r\nB Y\r\nA Z\r\nA Z\r\nA Z\r\nC Z\r\nC Y\r\nA Z\r\nB Z\r\nA Z\r\nC Y\r\nC Z\r\nB X\r\nA Z\r\nA Y\r\nB Y\r\nC Y\r\nC X\r\nC Z\r\nA Y\r\nC Z\r\nC Y\r\nA Y\r\nC Y\r\nA X\r\nC Y\r\nA Z\r\nC X\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nC X\r\nA X\r\nA Z\r\nA Y\r\nA Z\r\nA Z\r\nB X\r\nC Z\r\nA Z\r\nA Z\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nA Z\r\nB Z\r\nA Z\r\nA X\r\nA Z\r\nA Y\r\nB Y\r\nA Z\r\nA Y\r\nC Y\r\nC Y\r\nA Z\r\nA Z\r\nB Y\r\nA Z\r\nC Y\r\nC Z\r\nA Y\r\nB Y\r\nB X\r\nC Y\r\nC Y\r\nA Z\r\nC X\r\nB Y\r\nA X\r\nB Y\r\nA Z\r\nA Z\r\nB Y\r\nA Y\r\nC X\r\nA X\r\nC X\r\nA Z\r\nC X\r\nC Z\r\nA X\r\nC Y\r\nC Z\r\nC Y\r\nA X\r\nA Z\r\nC Z\r\nA Z\r\nA Z\r\nA Z\r\nB Y\r\nA Z\r\nA Z\r\nC Y\r\nC Z\r\nA Y\r\nA X\r\nA Z\r\nB Z\r\nC Y\r\nC Z\r\nC Y\r\nB Y\r\nA Z\r\nB Z\r\nC Y\r\nA Z\r\nC Y\r\nC X\r\nC Z\r\nA Y\r\nC X\r\nB X\r\nB Z\r\nB Y\r\nB X\r\nB X\r\nC Y\r\nC Z\r\nC Y\r\nC Y\r\nB Y\r\nC Y\r\nC Y\r\nA Z\r\nB Y\r\nC Y\r\nB Z\r\nA Y\r\nA Z\r\nB Y\r\nC Z\r\nA Z\r\nC Y\r\nC Y\r\nB Z\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nB X\r\nB Y\r\nB Y\r\nC Y\r\nA Z\r\nA X\r\nA Y\r\nB X\r\nA Y\r\nC Y\r\nA Z\r\nA Z\r\nB Z\r\nC Y\r\nC Y\r\nA Y\r\nB Z\r\nC Y\r\nA Z\r\nA Y\r\nB Y\r\nC Z\r\nB Y\r\nB Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nC X\r\nA Z\r\nB Y\r\nA X\r\nC Y\r\nC Y\r\nB X\r\nB Y\r\nA Z\r\nC Y\r\nB Y\r\nA Z\r\nC Y\r\nA Z\r\nB Z\r\nC Y\r\nC Y\r\nA Y\r\nC Y\r\nB X\r\nA Z\r\nC Y\r\nC Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nA Z\r\nB Y\r\nC Y\r\nC Z\r\nA Z\r\nA Y\r\nC Y\r\nC X\r\nC Y\r\nA Z\r\nC Y\r\nC Z\r\nA Y\r\nC X\r\nA Z\r\nC Z\r\nC Y\r\nA Z\r\nC Z\r\nC Z\r\nB Y\r\nA Z\r\nC Y\r\nA Z\r\nB Z\r\nA X\r\nA Z\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nA Y\r\nA Y\r\nA Z\r\nA X\r\nA Y\r\nB Z\r\nC Y\r\nC Z\r\nA Z\r\nB Z\r\nC Y\r\nB X\r\nC Y\r\nA Z\r\nA Z\r\nB Z\r\nC X\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nB Y\r\nA Z\r\nC Y\r\nA Y\r\nC Z\r\nB Y\r\nC Y\r\nA X\r\nC Y\r\nB Y\r\nA Z\r\nA Z\r\nC X\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nC X\r\nA Z\r\nB Y\r\nA Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nC Z\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nA X\r\nC Z\r\nB Z\r\nA Z\r\nC X\r\nB Y\r\nC Y\r\nB Y\r\nC Z\r\nC Z\r\nB Y\r\nA Y\r\nC Y\r\nA Z\r\nB Z\r\nC Y\r\nC Z\r\nA Z\r\nC Y\r\nA X\r\nA Z\r\nC Y\r\nC Z\r\nA Y\r\nC Y\r\nA Z\r\nC Y\r\nC Z\r\nB X\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nA Z\r\nC Y\r\nC Z\r\nA Z\r\nB X\r\nA Z\r\nA Y\r\nB Y\r\nA X\r\nA Z\r\nC Z\r\nC X\r\nA Y\r\nC Y\r\nA Z\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nC X\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nA Z\r\nC Z\r\nA Z\r\nA Z\r\nA Z\r\nA Z\r\nA X\r\nC Y\r\nB Z\r\nB Y\r\nA Z\r\nC Y\r\nC X\r\nA Y\r\nA Z\r\nC X\r\nA Z\r\nC X\r\nC Y\r\nA Y\r\nC X\r\nC X\r\nC Y\r\nA Y\r\nA Z\r\nB Z\r\nA Z\r\nC Y\r\nC X\r\nC Y\r\nB Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nA Z\r\nB Y\r\nA Z\r\nC Y\r\nB Y\r\nA Z\r\nC X\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nB X\r\nB X\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nC X\r\nB Y\r\nB Y\r\nA Z\r\nA X\r\nA Z\r\nC X\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nC Y\r\nB Z\r\nB Y\r\nA Z\r\nA Z\r\nC Y\r\nC X\r\nB Y\r\nA Y\r\nC Y\r\nC Z\r\nC Z\r\nA Z\r\nA Z\r\nC Z\r\nC Y\r\nA X\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nA Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nA X\r\nB Y\r\nB X\r\nA Z\r\nC Z\r\nC Y\r\nB Y\r\nB Y\r\nA Z\r\nB Y\r\nA Z\r\nA Y\r\nA X\r\nA X\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nB Z\r\nA Z\r\nA X\r\nA Z\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nC Z\r\nB Y\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nB Y\r\nA X\r\nC Y\r\nC Z\r\nB Z\r\nA Z\r\nA Z\r\nC Z\r\nC X\r\nA Z\r\nC Z\r\nB X\r\nB Z\r\nA Y\r\nC Y\r\nA Z\r\nC Z\r\nA Y\r\nB Z\r\nA Z\r\nA Z\r\nB Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Z\r\nA Z\r\nA Z\r\nA Z\r\nB Y\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nB Y\r\nC Z\r\nA Y\r\nB Y\r\nA X\r\nA Y\r\nB Y\r\nA Z\r\nC Z\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC X\r\nC Y\r\nC Z\r\nC Y\r\nA Z\r\nC Y\r\nB Z\r\nC Z\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nC Y\r\nC Y\r\nC Z\r\nC Y\r\nC X\r\nB Y\r\nA Z\r\nC X\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nA Z\r\nB Z\r\nA Z\r\nA Z\r\nB Z\r\nC Y\r\nA Y\r\nC Z\r\nB X\r\nB Y\r\nC Y\r\nA Z\r\nB Z\r\nA Z\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nA Z\r\nA Y\r\nB Z\r\nC Y\r\nA Z\r\nB Z\r\nB X\r\nA Z\r\nC Z\r\nB Y\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nC Z\r\nA Y\r\nC Y\r\nA Z\r\nC Z\r\nA Z\r\nB X\r\nC Y\r\nB X\r\nA Y\r\nC Y\r\nA Z\r\nB Y\r\nC Y\r\nA Y\r\nA Z\r\nA Z\r\nB Y\r\nC Y\r\nA Z\r\nA Z\r\nA Z\r\nA Z\r\nA Y\r\nC Y\r\nC Z\r\nB Y\r\nA Z\r\nC X\r\nC Y\r\nB Y\r\nC Y\r\nB Z\r\nC Y\r\nC Y\r\nB Y\r\nC X\r\nC Y\r\nC Y\r\nB Y\r\nA X\r\nC Y\r\nC Y\r\nB Y\r\nB Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nA Z\r\nB Y\r\nB X\r\nC Y\r\nA Y\r\nA Z\r\nC Y\r\nB Y\r\nA Z\r\nB Y\r\nA Y\r\nB Z\r\nC Y\r\nB Y\r\nA Z\r\nC Y\r\nC Y\r\nB Z\r\nC Y\r\nA X\r\nC Y\r\nA Z\r\nC Z\r\nA Z\r\nA Z\r\nB Y\r\nC Y\r\nC Y\r\nB Z\r\nB X\r\nC Y\r\nC X\r\nC Y\r\nA Y\r\nA Y\r\nC Y\r\nA Z\r\nA X\r\nA Z\r\nA Z\r\nA Z\r\nB Y\r\nC Z\r\nA Y\r\nA Y\r\nC Z\r\nA Y\r\nA Z\r\nB Z\r\nA Z\r\nC Y\r\nC Y\r\nB Y\r\nC Y\r\nB Z\r\nA Z\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nA Z\r\nA X\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nA Z\r\nA Z\r\nA Z\r\nB Y\r\nB Y\r\nB Z\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nC Y\r\nB Z\r\nA X\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC Z\r\nA Z\r\nA Y\r\nB Z\r\nB Y\r\nA Z\r\nC Z\r\nA Y\r\nB Y\r\nC Y\r\nA Z\r\nB Z\r\nC Y\r\nB Y\r\nB Z\r\nB Z\r\nC Y\r\nB X\r\nB Y\r\nC Y\r\nA Y\r\nA X\r\nC Z\r\nC Y\r\nA Z\r\nA Y\r\nC Y\r\nA Z\r\nA Z\r\nA Y\r\nA Z\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nA Z\r\nA Z\r\nA Z\r\nA Y\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nA Z\r\nA X\r\nB Y\r\nA Y\r\nA X\r\nC Y\r\nA Y\r\nC Z\r\nC X\r\nC Z\r\nC X\r\nA Z\r\nC Z\r\nA Z\r\nA X\r\nC Y\r\nC Z\r\nA Y\r\nA Z\r\nC Y\r\nA X\r\nB Y\r\nC Y\r\nC Z\r\nA X\r\nC Y\r\nA Z\r\nB Y\r\nB Y\r\nC Z\r\nA Y\r\nC Z\r\nA Z\r\nC Y\r\nA Z\r\nC X\r\nA X\r\nB Y\r\nC Y\r\nB Z\r\nB X\r\nC Y\r\nC Z\r\nA Z\r\nA Y\r\nC Y\r\nB Z\r\nA Z\r\nA Z\r\nC Z\r\nA Z\r\nB Y\r\nA Z\r\nC Y\r\nB Y\r\nC Y\r\nA Z\r\nB Y\r\nC Y\r\nA Z\r\nB Z\r\nB X\r\nC Z\r\nC Y\r\nA Y\r\nC Z\r\nA Z\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nA X\r\nB Y\r\nC Y\r\nC Y\r\nA Y\r\nC Y\r\nA Y\r\nC Y\r\nA Y\r\nA Z\r\nB Y\r\nA Z\r\nB Y\r\nC Y\r\nB Z\r\nC Y\r\nC Z\r\nA Y\r\nB Z\r\nA Z\r\nA Y\r\nC Y\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nC X\r\nC Y\r\nA Z\r\nC X\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nA Z\r\nA Z\r\nB Y\r\nA Y\r\nB X\r\nA Y\r\nC Y\r\nC Z\r\nA X\r\nB Y\r\nA Z\r\nA Z\r\nA Y\r\nA Y\r\nA Z\r\nB X\r\nA X\r\nB Y\r\nA Z\r\nC Y\r\nC Y\r\nB Y\r\nC Y\r\nB X\r\nA Z\r\nB Y\r\nB Y\r\nA Z\r\nA Z\r\nA Z\r\nC X\r\nB Z\r\nC Z\r\nA X\r\nA X\r\nB Y\r\nC Y\r\nC Z\r\nB Y\r\nC Z\r\nA Z\r\nA Z\r\nC Y\r\nC Z\r\nB Y\r\nB Z\r\nC Y\r\nA X\r\nA X\r\nB Z\r\nC Y\r\nC Y\r\nA Z\r\nB Y\r\nB Y\r\nC Y\r\nA Z\r\nC Y\r\nB Y\r\nB Y\r\nA Z\r\nA Z\r\nC Z\r\nA Z\r\nB Y\r\nB Y\r\nC Z\r\nA X\r\nB Y\r\nC X\r\nC Y\r\nC Y\r\nA X\r\nB Y\r\nB Z\r\nA Z\r\nB Y\r\nB Z\r\nA Z\r\nC Y\r\nC X\r\nC Z\r\nC X\r\nA Z\r\nA X\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nB Z\r\nC Z\r\nA Y\r\nC Y\r\nB Z\r\nB Y\r\nA Z\r\nA X\r\nC Y\r\nA Z\r\nC Y\r\nB Z\r\nA Z\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nC Z\r\nC Y\r\nA Z\r\nB Y\r\nC X\r\nA Z\r\nA Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nB Z\r\nC Z\r\nC Z\r\nC Y\r\nA Z\r\nA Y\r\nB Y\r\nC Y\r\nA Z\r\nA X\r\nA Y\r\nA Z\r\nA X\r\nB X\r\nB Y\r\nB Z\r\nA X\r\nC Y\r\nC Y\r\nB X\r\nA Z\r\nA Z\r\nA Y\r\nB X\r\nA Y\r\nC Y\r\nB Y\r\nB Y\r\nC Z\r\nC Y\r\nC Z\r\nB X\r\nB Z\r\nC Y\r\nA Z\r\nA Z\r\nB Z\r\nA Z\r\nA Z\r\nC Y\r\nB Y\r\nA Z\r\nA Y\r\nA Z\r\nA Y\r\nA Y\r\nB Z\r\nA Z\r\nC X\r\nC Y\r\nC Z\r\nC Y\r\nA Z\r\nA Y\r\nB Z\r\nC X\r\nB Y\r\nA Z\r\nA X\r\nA Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Y\r\nC Y\r\nA Z\r\nC X\r\nC Y\r\nC Y\r\nC Y\r\nC X\r\nA Z\r\nC Y\r\nA Z\r\nB Y\r\nB Y\r\nB X\r\nC Y\r\nB X\r\nC Y\r\nA Z\r\nC X\r\nB Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nB Z\r\nC X\r\nA Z\r\nC Z\r\nA Z\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nC X\r\nA Z\r\nA Z\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nA Z\r\nC Y\r\nA Z\r\nA Z\r\nA Z\r\nC X\r\nC X\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Z\r\nC Y\r\nB Y\r\nA Z\r\nC Y\r\nB Y\r\nC Y\r\nB X\r\nA Z\r\nA Z\r\nC Y\r\nA X\r\nB Y\r\nB Z\r\nA Z\r\nA Z\r\nC X\r\nA Z\r\nB Y\r\nA Z\r\nA Z\r\nA X\r\nA Z\r\nC Y\r\nA Z\r\nB Y\r\nA X\r\nA X\r\nC Z\r\nA X\r\nB Y\r\nA Z\r\nA X\r\nB X\r\nC Y\r\nC Z\r\nC Y\r\nB Y\r\nA X\r\nC X\r\nA Z\r\nA Z\r\nA Z\r\nC X\r\nC X\r\nA Z\r\nB Y\r\nA Z\r\nA Z\r\nC Y\r\nB X\r\nC X\r\nB X\r\nB Y\r\nB Z\r\nC Y\r\nA Z\r\nA Z\r\nC Z\r\nB Y\r\nA Z\r\nC Y\r\nA Y\r\nA Z\r\nA X\r\nC Y\r\nC Y\r\nB Z\r\nB Y\r\nB X\r\nC X\r\nA Z\r\nB X\r\nB Z\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nC Y\r\nC Z\r\nC Y\r\nB Y\r\nC Y\r\nB Z\r\nC Z\r\nC Y\r\nB X\r\nA Z\r\nB Y\r\nC Y\r\nB Z\r\nC Y\r\nC Z\r\nA Z\r\nC X\r\nA Z\r\nB Z\r\nB Y\r\nA Z\r\nC X\r\nC Y\r\nB Y\r\nB Z\r\nC Y\r\nB Z\r\nB Z\r\nC X\r\nC Y\r\nA Y\r\nB Y\r\nC Z\r\nC X\r\nC Y\r\nC Y\r\nA Z\r\nC X\r\nC Z\r\nB Z\r\nA X\r\nB Y\r\nB Y\r\nB Y\r\nC Z\r\nB Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nC Z\r\nC Y\r\nC X\r\nC Y\r\nB X\r\nB Y\r\nB X\r\nA Z\r\nC X\r\nC Z\r\nB Z\r\nA Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nC Y\r\nB X\r\nA Z\r\nC Z\r\nC Y\r\nC Y\r\nC Y\r\nC Z\r\nA Z\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nA Z\r\nA Z\r\nA Z\r\nB X\r\nC Y\r\nC Z\r\nB X\r\nA Z\r\nC Z\r\nA Z\r\nA Z\r\nA Z\r\nC Z\r\nB Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nA Y\r\nC Z\r\nA Z\r\nC Y\r\nA Z\r\nA X\r\nA Y\r\nC Y\r\nA Z\r\nC Y\r\nB Y\r\nA Z\r\nA X\r\nC Y\r\nC Y\r\nA Y\r\nA Z\r\nC Z\r\nA X\r\nC Y\r\nA Z\r\nC Y\r\nC Z\r\nA Z\r\nC Y\r\nC Z\r\nA Z\r\nB Y\r\nA Z\r\nB Y\r\nB X\r\nC Y\r\nC Z\r\nA X\r\nA Z\r\nA X\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nA Y\r\nC Y\r\nB Z\r\nA Y\r\nA X\r\nC Y\r\nC Z\r\nA Z\r\nA Z\r\nC Z\r\nC Y\r\nC Y\r\nA Y\r\nA Y\r\nC Y\r\nC Y\r\nC Z\r\nA Y\r\nC Y\r\nA Z\r\nB Z\r\nB Y\r\nB Y\r\nA Z\r\nA Z\r\nB Y\r\nA Z\r\nC Y\r\nC Y\r\nC Z\r\nB Y\r\nA Z\r\nA Y\r\nA Z\r\nA Z\r\nA Y\r\nA Z\r\nA Z\r\nA Z\r\nC Y\r\nA Z\r\nA Z\r\nC Y\r\nB Z\r\nB Y\r\nC Z\r\nC Y\r\nA Y\r\nB X\r\nC Z\r\nA Z\r\nB Z\r\nA Z\r\nB Y\r\nA Z\r\nB Y\r\nA Z\r\nB Y\r\nB Y\r\nC Y\r\nA Z\r\nA Z\r\nC Z\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nC Y\r\nC Y\r\nA Z\r\nB Z\r\nA Z\r\nC Y\r\nA Z\r\nB Z\r\nB Y\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nC Y\r\nB Z\r\nC Y\r\nC Z\r\nA X\r\nC Y\r\nB Z\r\nB Z\r\nA X\r\nA X\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nA Z\r\nA X\r\nC Y\r\n";
    }
}
