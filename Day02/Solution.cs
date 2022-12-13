using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day02
{
    public static class Solution
    {
        private enum WinningType
        {
            WIN = 6,
            DRAW = 3,
            LOSE = 0
        }
        private enum HandshapeType
        {
            ROCK = 1,
            PAPER = 2,
            SCISSORS = 3
        }

        private static List<List<string>> FormatFile()
        {
            List<List<string>> list = new List<List<string>>();
            string[] lines = File.ReadAllLines(@"D:\AoC\2022_C#\AdventOfCode2022\Day02\File.txt");

            foreach (string line in lines)
            {
                List<string> temp = line.Split(' ').ToList<string>();
                list.Add(temp);
            }
            return list;
        }

        // AUFGABE 01 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static readonly Dictionary<string, HandshapeType> stringToHandshape = new()
        {
            {"A", HandshapeType.ROCK },
            {"B", HandshapeType.PAPER },
            {"C", HandshapeType.SCISSORS},
            {"X", HandshapeType.ROCK },
            {"Y", HandshapeType.PAPER },
            {"Z", HandshapeType.SCISSORS},
        };

        private static WinningType checkingWinningCondition(HandshapeType me, HandshapeType opponent)
        {
            if (me == opponent) return WinningType.DRAW;
            if ((me == HandshapeType.ROCK && opponent == HandshapeType.SCISSORS) ||
                (me == HandshapeType.SCISSORS && opponent == HandshapeType.PAPER) ||
                (me == HandshapeType.PAPER && opponent == HandshapeType.ROCK))
                return WinningType.WIN;
            else
                return WinningType.LOSE;
        }

        private static HandshapeType getHandshapeFromWinningCondition(WinningType me, HandshapeType opponent)
        {
            switch (me)
            {
                case WinningType.WIN:
                    return winning[opponent];
                case WinningType.LOSE:
                    return losing[opponent];
                default:
                    return opponent;

            }
        }

        private static int calculatePointsFromOneGame(HandshapeType me, HandshapeType opponent)
        {
            var winningCondition = checkingWinningCondition(me, opponent);
            return (int)winningCondition + (int)me;
        }

        public static int CalculateMyPointsFirstStrategie()
        {
            List<List<string>> puzzleInput = FormatFile();
            List<int> points = new();

            foreach (var input in puzzleInput)
            {
                var opponent = input[0];
                var me = input[1];
                points.Add(calculatePointsFromOneGame(stringToHandshape[me], stringToHandshape[opponent]));
            }
            return points.Sum();
        }

        // AUFGABE 02 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static readonly Dictionary<string, WinningType> stringToWinningType = new()
        {
            {"X", WinningType.LOSE },
            {"Y", WinningType.DRAW },
            {"Z", WinningType.WIN }
        };
        private static readonly Dictionary<HandshapeType, HandshapeType> winning = new()
        {
            {HandshapeType.SCISSORS, HandshapeType.ROCK},
            {HandshapeType.ROCK, HandshapeType.PAPER},
            {HandshapeType.PAPER, HandshapeType.SCISSORS}
        };
        private static readonly Dictionary<HandshapeType, HandshapeType> losing = new()
        {
            {HandshapeType.ROCK, HandshapeType.SCISSORS},
            {HandshapeType.PAPER, HandshapeType.ROCK},
            {HandshapeType.SCISSORS, HandshapeType.PAPER}
        };

        public static int CalculateMyPointsSecondStrategie()
        {
            List<List<string>> puzzleInput = FormatFile();
            List<int> points = new();

            foreach (var input in puzzleInput)
            {
                var opponent = input[0];
                var me = input[1];
                var winningType = stringToWinningType[me];
                var myHandshape = getHandshapeFromWinningCondition(winningType, stringToHandshape[opponent]);
                points.Add((int)winningType + (int)myHandshape);
            }
            return points.Sum();
        }







    }
}
