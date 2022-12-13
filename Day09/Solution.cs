using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day09
{
    public static class Solution
    {
        public enum Direction { RIGHT, LEFT, UP, DOWN,
                                RU,    LU,   RD, LD };

        private static List<List<string>> Field = new();
        private static List<(int Row, int Col)> positionCounter = new List<(int Row, int Col)>()
        {         
            (0,0),   // Overlapping
            (0,-1),  // Left
            (1,0),   // Up
            (0,1),   // Right 
            (-1,0),  // Down
            (1,1),   // RU
            (-1,1),  // RD
            (-1,-1), // LD
            (1,-1)   // LU
        };

        public class RopeObject
        {
            public (int Row, int Col) Position { get; set; }
            public RopeObject PrevRopeObj;

            private (int Row, int Col) addArr((int Row, int Col) arr1, (int Row, int Col) arr2)
            {
                arr1 = (arr1.Row + arr2.Row, arr1.Col + arr2.Col);
                return arr1;
            }

            public bool checkAdjacents()
            {
                (int Row, int Col) currentPos;
                foreach (var posCounter in positionCounter)
                {
                    currentPos = Position;
                    currentPos = addArr(currentPos, posCounter);
                    if (PrevRopeObj.Position.Row == currentPos.Row && PrevRopeObj.Position.Col == currentPos.Col) return true;
                }
                return false;
            }
        }

        public class Head : RopeObject
        {
            public Head((int Row, int Col) position)
            {
                Position = position;
                PrevRopeObj = null;
            }

            public void move(Direction direction)
            {
                switch (direction)
                {
                    case Direction.LEFT:
                        Position = (Position.Row, Position.Col - 1); 
                        break;
                    case Direction.RIGHT:
                        Position = (Position.Row, Position.Col + 1);
                        break;
                    case Direction.DOWN:
                        Position = (Position.Row -1, Position.Col);
                        break;
                    case Direction.UP:
                        Position = (Position.Row + 1, Position.Col);
                        break;
                }
            }
        }
        
        public class Trail : RopeObject
        {

            public HashSet<(int Row, int Col)> VisitPos { get; set; } = new();

            public Trail(RopeObject ropeObject)
            {
                PrevRopeObj = ropeObject;
                VisitPos.Add(Position);
            }

            public void move(Direction direction)
            {
                switch (direction)
                {
                    case Direction.LEFT:
                        Position = (Position.Row, Position.Col - 1);
                        break;
                    case Direction.RIGHT:
                        Position = (Position.Row, Position.Col + 1);
                        break;
                    case Direction.DOWN:
                        Position = (Position.Row - 1, Position.Col);
                        break;
                    case Direction.UP:
                        Position = (Position.Row + 1, Position.Col);
                        break;
                    case Direction.RU:
                        Position = (Position.Row + 1, Position.Col + 1);
                        break;
                    case Direction.LU:
                        Position = (Position.Row + 1, Position.Col - 1);
                        break;
                    case Direction.RD:
                        Position = (Position.Row - 1, Position.Col + 1);
                        break;
                    case Direction.LD:
                        Position = (Position.Row - 1, Position.Col - 1);
                        break;
                }

                VisitPos.Add(Position);
                
            }

        }

        private static List<Tuple<Direction, int>> GetMotions()
        {
            List<Tuple<Direction, int>> motions = new();
            string[] lines = File.ReadAllLines(@"D:\AoC\2022_C#\AdventOfCode2022\Day09\File.txt");

            foreach (string line in lines)
            {
                var spliLine = line.Split(" ");
                Direction dir = Direction.RIGHT;
                int number = 0;
                switch(spliLine[0])
                {
                    case "R":
                        dir = Direction.RIGHT;
                        break;
                    case "L":
                        dir = Direction.LEFT;
                        break;
                    case "U":
                        dir = Direction.UP;
                        break;
                    case "D":
                        dir = Direction.DOWN;
                        break;
                }
                number = Convert.ToInt32(spliLine[1]);
                motions.Add(new Tuple<Direction, int>(dir, number));
            }

            return motions;
        }

        private static Direction GetDirectionOfTrail((int Row, int Col) posHeader, (int Row, int Col) posTrail)
        {
            if (posHeader.Row == posTrail.Row)
            {
                if (posHeader.Col > posTrail.Col)
                    return Direction.RIGHT;
                else
                    return Direction.LEFT;
            }
            else if (posHeader.Col == posTrail.Col)
            {
                if (posHeader.Row > posTrail.Row)
                    return Direction.UP;
                else
                    return Direction.DOWN;
            }
            else if (posHeader.Row < posTrail.Row)
            {
                if (posHeader.Col > posTrail.Col)
                    return Direction.RD;
                else
                    return Direction.LD;
            }
            else 
            {
                if (posHeader.Col > posTrail.Col)
                    return Direction.RU;
                else
                    return Direction.LU;
            } 
                
        }

        private static void initField(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Field.Add(new List<string>());
                for (int j = 0; j < length; j++)
                {
                    Field[i].Add("-");
                }
            }
        }

        public static int GetNumberOfVisitPositions()
        {
            Head head = new Head((0,0));
            Trail trail = new Trail(head);

            var motions = GetMotions();
            foreach (var motion in motions)
            {
                for (int i = 0; i < motion.Item2; i++)
                {
                    head.move(motion.Item1);
                    if (!trail.checkAdjacents())
                    {
                        trail.move(GetDirectionOfTrail(head.Position, trail.Position));
                    }
                }
            }
            return trail.VisitPos.Count();
        }

        public static int GetNumberOfVisitPositionLongerRope()
        {
            Head head = new Head((0, 0));
            Trail temp = new Trail(head);
            List<Trail> trails = new List<Trail>();
            for (int i = 0; i < 9; i++)
            {
                trails.Add(temp);
                temp = new Trail(temp);
            }

            var motions = GetMotions();
            foreach (var motion in motions)
            {
                for (int i = 0; i < motion.Item2; i++)
                {
                    head.move(motion.Item1);
                    foreach (var trail in trails)
                    {
                        if (!trail.checkAdjacents())
                        {
                            trail.move(GetDirectionOfTrail(head.Position, trail.Position));
                        }
                    }
                }
            }
            return trails[8].VisitPos.Count();
        }
    }

}
