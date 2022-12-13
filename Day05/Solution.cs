using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day05
{
    public static class Solution
    {
        public enum OPCODE
        {
            NUMBER,
            SOURCE,
            DESTINATION
        }

        private static List<string> SplitFile()
        {
            var lines = File.ReadAllText(@"D:\AoC\2022_C#\AdventOfCode2022\Day05\File.txt");
            return lines.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private static List<List<string>> rotateList(List<List<string>> list)
        {
            var rotateList = new List<List<string>>();

            for (int i = 0; i < list[0].Count; i++) 
                rotateList.Add(new List<string>()); 
            
            for (int i=0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++ )
                {
                    if (list[j][i] != "   ")
                    {
                        rotateList[i].Add(list[j][i]);
                    }
                }
            }
            return rotateList;
        }

        private static List<List<string>> GetStacksOrCrates(string text)
        {
            string pattern = @"(\s\s\s)|[A-Z]";
            List<List<string>> stacks = new();
            Regex rgx = new Regex(pattern);
            var lines = text.Split('\n');
            foreach (var line in lines)
            {
                stacks.Add(rgx.Matches(line).ToList().Select(x => x.Value).ToList());
            }
            stacks.RemoveAt(stacks.Count - 1);

            return rotateList(stacks);
        }

        private static List<Dictionary<OPCODE, int>> GetOperations(string text)
        {
            List<Dictionary<OPCODE, int>> operations = new();
            Regex regex = new Regex(@"([0-9]+)");
            var rawOperations = text.Split('\n');
            foreach (var op in rawOperations)
            {
                var o = regex.Matches(op).ToList().Select(x => Convert.ToInt32(x.Value)).ToList();
                operations.Add(new Dictionary<OPCODE, int>()
                {
                    { OPCODE.NUMBER, o[0]},
                    { OPCODE.SOURCE, o[1]},
                    { OPCODE.DESTINATION, o[2]}
                });
            }
            return operations;
        }


        public static string GetCratesOnTop()
        {
            var lines = SplitFile();
            //var stacks = GetStacksOrCrates(lines[0]);
            List<List<string>> stacks = new List<List<string>>() {
                new List<string>() {"G", "W", "L", "J", "B", "R", "T", "D"},
                new List<string>() {"C", "W", "S"},
                new List<string>() {"M", "T", "Z", "R"},
                new List<string>() {"V", "P", "S", "H", "C", "T", "D"},
                new List<string>() {"Z", "D", "L", "T", "P", "G"},
                new List<string>() {"D", "C", "Q", "J", "Z", "R", "R", "B", "F"},
                new List<string>() {"R", "T", "F", "M", "J", "D", "B", "S"},
                new List<string>() {"M", "V", "T", "B", "R", "H", "L"},
                new List<string>() {"V", "S", "D", "P", "Q"},
            };
            var operations = GetOperations(lines[1]);
            var result = "";

            foreach (var op in operations)
            {
                var src = op[OPCODE.SOURCE] - 1;
                var dest = op[OPCODE.DESTINATION] - 1;
                for (int nr = 0; nr < op[OPCODE.NUMBER]; nr++)
                {
                    stacks[dest].Insert(0, stacks[src][0]);
                    stacks[src].RemoveAt(0);
                }
            }
            foreach (var letter in stacks)
            {
                result += letter[0];
            }
            return result;
        }

        public static string GetCratesOnTop2()
        {
            var lines = SplitFile();
            var operations = GetOperations(lines[1]);
            var result = "";
            List<List<string>> stacks = new List<List<string>>() {
                new List<string>() {"G", "W", "L", "J", "B", "R", "T", "D"},
                new List<string>() {"C", "W", "S"},
                new List<string>() {"M", "T", "Z", "R"},
                new List<string>() {"V", "P", "S", "H", "C", "T", "D"},
                new List<string>() {"Z", "D", "L", "T", "P", "G"},
                new List<string>() {"D", "C", "Q", "J", "Z", "R", "B", "F"},
                new List<string>() {"R", "T", "F", "M", "J", "D", "B", "S"},
                new List<string>() {"M", "V", "T", "B", "R", "H", "L"},
                new List<string>() {"V", "S", "D", "P", "Q"},
            };

            int count = 0;
            foreach (var op in operations)
            {
                count++;
                var src = op[OPCODE.SOURCE] - 1;
                var dest = op[OPCODE.DESTINATION] - 1;

                stacks[dest].InsertRange(0, stacks[src].GetRange(0, op[OPCODE.NUMBER]));
                stacks[src].RemoveRange(0, op[OPCODE.NUMBER]);
                
            }

            foreach (var letter in stacks)
            {
                result += letter[0];
            }
            return result;
        }
        
    }
}
