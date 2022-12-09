namespace AdventOfCode2022
{
    internal class Day8 : Day
    {
       
        public override void Run()
        {
            string dir = "../../../input/";
            string path = "day8.txt";
            string[] lines = ReadInput(dir + path);

            Tree[,] forest = new Tree[99, 99];

            // go through lines
            for (int line = 0; line < lines.Length; line++)
            {
                for (int i = 0; i < 99; i++)
                {
                    int num = lines[line][i] - '0';
                    forest[line,i] = new Tree(num);

                    // display forest
                    //Console.Write(num);
                }
                //Console.WriteLine();
            }

            // sight check left + right
            for (int row = 0; row < 99; row++)
            {
                int lastHeight = -1;

                // LR
                for (int col = 0; col < 99; col++)
                {
                    Tree t = forest[row,col];

                    // stop if hidden
                    if (t.Height <= lastHeight) continue;

                    lastHeight = t.Height;
                    t.Seen = true;
                    //Console.WriteLine("Saw tree at ({0},{1})", row, col);

                }

                lastHeight = -1;
                // RL
                for (int col = 98; col >= 0; col--)
                {
                    Tree t = forest[row, col];

                    // stop if hidden
                    if (t.Height <= lastHeight) continue;

                    lastHeight = t.Height;
                    t.Seen = true;
                    //Console.WriteLine("Saw tree at ({0},{1})", row, col);

                }
            }

            // sight check top + bottom
            for (int col = 0; col < 99; col++)
            {
                int lastHeight = -1;

                // UD
                for (int row = 0; row < 99; row++)
                {
                    Tree t = forest[row, col];

                    // stop if hidden
                    if (t.Height <= lastHeight) continue;

                    lastHeight = t.Height;
                    t.Seen = true;
                    //Console.WriteLine("Saw tree at ({0},{1})", row, col);

                }

                lastHeight = -1;
                // DU
                for (int row = 98; row >= 0; row--)
                {
                    Tree t = forest[row, col];

                    // stop if hidden
                    if (t.Height <= lastHeight) continue;

                    lastHeight = t.Height;
                    t.Seen = true;
                    //Console.WriteLine("Saw tree at ({0},{1})", row, col);
                }
            }

            // total seen
            int total = 0;
            foreach(Tree tree in forest)
            {
                if (tree.Seen)
                    total++;
            }


            Tree mostScenicTree = new Tree(-1);
            int bestScenicScore = 0;

            // go through lines (made for part 1 debugging)
            // While we do this, do part 2
            for (int line = 0; line < lines.Length; line++)
            {
                for (int i = 0; i < 99; i++)
                {
                    Tree tree = forest[line, i];
                    int thisScenicScore = GetScenicScore(forest, line, i);

                    if (thisScenicScore > bestScenicScore)
                    {
                        mostScenicTree = tree;
                        bestScenicScore = thisScenicScore;
                        //Console.WriteLine("Tree {0} has new best SS of {1}", tree, thisScenicScore);
                        tree.Scenic = true;
                    }


                    if (tree.Seen)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (tree.Scenic)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(tree.Height + " ");
                    Console.ResetColor();
                   
                }
                Console.WriteLine();
            }

            Console.WriteLine("There are {0} visible trees from outside the forest", total);
            Console.WriteLine("The tree with the best SS is {0} with a SS of {1}", mostScenicTree, bestScenicScore);
        }

        int GetScenicScore(Tree[,] forest, int row, int col)
        {
            Tree t = forest[row, col];
            int scoreup = 0;
            int scoredown = 0;
            int scoreleft = 0;
            int scoreright = 0;

            // spread out
            // oops was checking self trees (needed 1 offset to start)
            // oops also didnt check 0
            // up
            for (int y = row - 1; y >= 0; y--)
            {
                scoreup++;
                if (forest[y, col].Height >= t.Height) break;
            }

            // down
            for (int y = row + 1; y < 99; y++)
            {
                scoredown++;
                if (forest[y, col].Height >= t.Height) break;
            }

            // left
            for (int x = col - 1; x >= 0; x--)
            {
                scoreleft++;
                if (forest[row, x].Height >= t.Height) break;
            }

            // right
            for (int x = col + 1; x < 99; x++)
            {
                scoreright++;
                if (forest[row, x].Height >= t.Height) break;

            }

            int ss = scoreup * scoredown * scoreleft * scoreright;
            if (ss > 0)
            {
                Console.Write("");
            }
            //Console.WriteLine("SS: {0}", ss);
            return ss;
        }

        class Tree
        {
            public bool Seen { get; set; }
               
            public int Height { get; set; }
            // debugging lol
            public bool Scenic { get; set; }

            public Tree(int height, bool seen = false)
            {
                Seen = seen;
                Height = height;
            }

            public override string ToString()
            {
                return String.Format("Height: {0} | Seen: {1}", Height, Seen);
            }
        }

        // Copy / paste input string in the quotes
        static string[] ReadInput(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
