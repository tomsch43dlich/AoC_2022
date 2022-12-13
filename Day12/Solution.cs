using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day12
{
    public static class Solution
    {
        private static List<List<char>> GetHighGrid()
        {
            return File.ReadAllLines(@"D:\AoC\2022_C#\AdventOfCode2022\Day12\File.txt").Select(x => x.ToCharArray().ToList()).ToList();
        }
        private static ((int Row, int Col), (int Row, int Col)) GetStartAndEndPos(List<List<char>> highGrid)
        {

            (int Row, int Col) start = (0,0);
            (int Row, int Col) end = (0,0);
            for (int r = 0; r < highGrid.Count; r++)
            {
                for (int c= 0; c < highGrid[r].Count; c++)
                {
                    var ch = highGrid[r][c];
                    if (ch == 'S')
                        start = (r, c);
                    if (ch == 'E')
                        end = (r, c);
                }
            }
            ((int Row, int Col), (int Row, int Col)) pos = (start, end);
            return pos;
        }
        private static int GetHight(char ch)
        {
            string lowercase_ASCII = "abcdefghijklmnopqrstuvwxyz";
            if (lowercase_ASCII.Contains(ch))
                return lowercase_ASCII.IndexOf(ch);
            if (ch == 'S')
                return 0;
            if (ch == 'E')
                return 25;
            return -1;
        }
        private static List<(int Row, int Col)> GetNeighbors(List<List<char>> highGrid, (int Row, int Col) pos)
        {
            List<(int Row, int Col)> posAdd = new() { (1, 0), (-1, 0), (0, 1), (0, -1) };
            List<(int Row, int Col)> neighbors = new();
            foreach (var (arow, acol) in posAdd)
            {
                var rrow = arow + pos.Row;
                var ccol = acol + pos.Col;
                var nrRow = highGrid.Count;
                var nrCol = highGrid[0].Count;
                if (!(0 <= rrow && rrow < nrRow && 0 <= ccol && ccol < nrCol))
                    continue;
                if (GetHight(highGrid[rrow][ccol]) <= GetHight(highGrid[pos.Row][pos.Col]) + 1)
                    neighbors.Add((rrow, ccol));
            }
            return neighbors;
        }
        private static List<(int Row, int Col)> GetNeighbors2(List<List<char>> highGrid, (int Row, int Col) pos)
        {
            List<(int Row, int Col)> posAdd = new() { (1,0), (-1, 0), (0,1), (0,-1) };
            List<(int Row, int Col)> neighbors = new();
            foreach (var (arow, acol) in posAdd)
            {
                var rrow = arow + pos.Row;
                var ccol = acol + pos.Col;
                var nrRow = highGrid.Count;
                var nrCol = highGrid[0].Count;
                if (!(0 <= rrow && rrow < nrRow && 0 <= ccol && ccol < nrCol))
                    continue;
                if (GetHight(highGrid[rrow][ccol]) >= GetHight(highGrid[pos.Row][pos.Col]) - 1)
                    neighbors.Add((rrow, ccol));
            }
            return neighbors;
        }
        private static List<List<bool>> GetBoolField(int high, int wide)
        {
            List<List<bool>> field = new();
            for (int i = 0; i < high; i++)
            {
                field.Add(new List<bool>());
                for (int j = 0; j < wide; j++)
                {
                    field[i].Add(false);
                }
            }
            return field;
        }

        public static int GetLengthOfShortestPath()
        {
            var highGrid = GetHighGrid();
            var (start, end) = GetStartAndEndPos(highGrid);
            var visited = GetBoolField(highGrid.Count, highGrid[0].Count);
            Queue<(int Step, (int Row, int Col))> queue = new Queue<(int step, (int Row, int Col))>();
            queue.Enqueue((0, start));
            while (true)
            {
                var currentPos = queue.Dequeue();
                var pos = currentPos.Item2;
                if (visited[pos.Row][pos.Col]) continue;
                visited[pos.Row][pos.Col] = true;

                if (pos == end)
                {
                    return currentPos.Step;
                    break;
                }

                foreach (var neighbor in GetNeighbors(highGrid, pos))
                {
                    queue.Enqueue((currentPos.Step + 1, neighbor));
                }
            }
        }

        public static int GetLengthOfShortestPath2()
        {
            var highGrid = GetHighGrid();
            var (start, end) = GetStartAndEndPos(highGrid);
            var visited = GetBoolField(highGrid.Count, highGrid[0].Count);
            Queue<(int Step, (int Row, int Col))> queue = new Queue<(int step, (int Row, int Col))>();
            queue.Enqueue((0, end));
            while (true)
            {
                var currentPos = queue.Dequeue();
                var pos = currentPos.Item2;
                if (visited[pos.Row][pos.Col]) continue;
                visited[pos.Row][pos.Col] = true;

                if (GetHight(highGrid[pos.Row][pos.Col]) == 0)
                {
                    return currentPos.Step;
                    break;
                }

                foreach (var neighbor in GetNeighbors2( highGrid,pos))
                {
                    queue.Enqueue((currentPos.Step + 1, neighbor));
                }
            }
        }
    }
}
