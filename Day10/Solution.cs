using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day10
{
    public static class Solution
    {
        private static List<int> GetProgram()
        {
            List<int> program = new();
            var result = File.ReadAllLines(@"D:\AoC\2022_C#\AdventOfCode2022\Day10\File.txt");
            foreach (var res in result)
            {
                if (res == "noop") 
                    program.Add(0); 
                else 
                    program.Add(Convert.ToInt32(res.Split(" ")[1]));
            }
            return program;
        }

        public static int GetSumOfSignalStrength()
        {
            var program = GetProgram();
            var register = 1;
            var cycle = 0;
            var checking = new List<int>() { 20, 60, 100, 140, 180, 220 };
            var signalStrength = new List<int>();
            foreach (var op in program)
            {
                if (op == 0)
                {
                    cycle += 1;
                    if (checking.IndexOf(cycle) > -1) signalStrength.Add(cycle * register);
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        cycle += 1;
                        if (checking.IndexOf(cycle) > -1) 
                            signalStrength.Add(cycle * register);
                    }
                    register += op;
                }
                if (cycle >= 220) break;
            }
            return signalStrength.Sum();
        }

        ////////////////////////////////////
        private static bool checkIfOverlapping(int register, int length)
        {
            if (register == length || register+1 == length || register+2 == length) return true;
            return false;
        }
        private static void drawPixel (int register, List<string> image)
        {
            if (checkIfOverlapping(register, image.Count()))
                image.Add("#");
            else
                image.Add(".");
        }
        private static string formatImage(List<List<string>> image)
        {
            string result = "";
            foreach (var imageLine in image)
            {
                result += "\n";
                foreach (var pixel in imageLine)
                {
                    result += pixel;
                }
            }
            return result;
        }

        public static string GetCRTImage()
        {
            var program = GetProgram();
            var register = 0;
            var cycle = 0;
            List<List<string>> image = new() { };
            List<string> imageLine = new() { };
            foreach (var op in program)
            {
                if (op == 0)
                {
                    drawPixel(register, imageLine);
                    cycle += 1;
                    if (imageLine.Count() % 40 == 0)
                    {
                        var temp = new List<string>();
                        temp.AddRange(imageLine);
                        imageLine.Clear();
                        image.Add(temp);
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        drawPixel(register, imageLine);
                        cycle += 1;
                        if (imageLine.Count() % 40 == 0)
                        {
                            var temp = new List<string>();
                            temp.AddRange(imageLine);
                            imageLine.Clear();
                            image.Add(temp);
                        }
                    }
                    register += op;
                }
            }
            return formatImage(image);
        }
    }
}
