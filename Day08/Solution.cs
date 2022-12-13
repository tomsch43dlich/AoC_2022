using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day08
{
    public static class Solution
    {
        private enum Direction { RIGHT, LEFT, TOP, DOWN };

        private static List<List<int>> _treeField = null;
        private static List<List<int>> TreeField
        {
            get
            {
                if (_treeField == null)
                {
                    List<List<int>> result = new List<List<int>>();
                    string[] lines = File.ReadAllLines(@"D:\AoC\2022_C#\AdventOfCode2022\Day08\File.txt");

                    foreach (var line in lines)
                    {
                        result.Add(line.ToList().Select(x => Convert.ToInt32(x.ToString())).ToList());
                    }
                    _treeField = result;
                }
                return _treeField;
            }
        }
        private static List<Tree> AllTrees { get; set; } = new();

        private static List<int> getTreeList(int high, Direction direction)
        {
            List<int> result = new List<int>();
            switch (direction)
            {
                case Direction.LEFT:
                    break;
                case Direction.RIGHT:
                    break;
                case Direction.TOP:
                    break;
                case Direction.DOWN:
                    break;
            }
            return result;
        }

        public class Tree
        {
            public int High { get; set; } = 0;
            public int Row { get; set; } = 0;
            public int Col { get; set; } = 0;

            public List<int> RightTrees { get; set; }
            public List<int> LeftTrees { get; set; }
            public List<int> TopTrees { get; set; }
            public List<int> DownTrees { get; set; }

            public List<List<int>> VisibleLines { get; set; } = new();

            public Tree(int row, int col)
            {
                Row = row;
                Col = col;
                High = TreeField[row][col];
                RightTrees = getTreeList(this, Direction.RIGHT);
                LeftTrees = getTreeList(this, Direction.LEFT);
                TopTrees = getTreeList(this, Direction.TOP);
                DownTrees = getTreeList(this, Direction.DOWN);
            }

            private bool IsVisible()
            {
                if (RightTrees.FindAll(x => x >= High).Count() == 0 ||
                    LeftTrees.FindAll(x => x >= High).Count() == 0 ||
                    DownTrees.FindAll(x => x >= High).Count() == 0 ||
                    TopTrees.FindAll(x => x >= High).Count() == 0 )  return true;
                return false;
            }

            private static List<int> getTreeList(Tree tree, Direction direction)
            {
                List<int> result = new List<int>();
                var col = tree.Col;
                var row = tree.Row;
                var high = tree.High;

                try
                {
                    while (true)
                    {
                        switch (direction)
                        {
                            case Direction.LEFT:
                                col--;
                                break;
                            case Direction.RIGHT:
                                col++;
                                break;
                            case Direction.TOP:
                                row--;
                                break;
                            case Direction.DOWN:
                                row++;
                                break;
                        }
                        var tr = TreeField[row][col];
                        if (tr >= high)
                        {
                            result.Add(tr);
                            break;
                        }
                        result.Add(tr);
                    }
                } 
                catch 
                {
                    tree.VisibleLines.Add(result);
                }
                return result;
            }

        }

        public static int GetNumberOfVisbleTree()
        {
            List<Tree> trees = new List<Tree>();
            for (int row = 0; row < TreeField.Count(); row++)
            {
                Console.Clear();
                Console.WriteLine(row + "%");
                for (int col = 0; col < TreeField[row].Count(); col++)
                {
                    var tree = new Tree(row, col);
                    AllTrees.Add(tree);
                    if (tree.VisibleLines.Count > 0) trees.Add(tree);
                }
            }
            Console.Clear();
            return trees.Count();
        }

        public static int GetHighestScenicScore()
        {
            var AllScores = new List<int>();

            foreach (var tree in AllTrees)
            {
                AllScores.Add(tree.LeftTrees.Count() * tree.RightTrees.Count() * tree.DownTrees.Count() * tree.TopTrees.Count());
            }

            return AllScores.Max();
        }
    }
}
