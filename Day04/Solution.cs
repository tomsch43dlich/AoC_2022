using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day04
{
    public static class Solution
    {
        private static List<int> getSectionList(string unformatSections)
        {
            List<int> sectionList = new();
            var sections = unformatSections.Split('-').Select(x => Convert.ToInt32(x)).ToList();

            for (var i = sections[0]; i <= sections[1]; i++)
            {
                sectionList.Add(i);
            }
            return sectionList;
        }

        private static List<List<List<int>>> formatFile()
        {
            List<List<List<int>>> sectionsForEachPair = new();
            string[] lines = File.ReadAllLines(@"D:\AoC\2022_C#\AdventOfCode2022\Day04\File.txt");

            foreach (string line in lines)
            {
                List<List<int>> temp = new();
                var section = line.Split(',');
                temp.Add(getSectionList(section[0]));
                temp.Add(getSectionList(section[1]));
                sectionsForEachPair.Add(temp);  
            }
            return sectionsForEachPair;
        }

        public static int getNumberPairWithSubSets()
        {
            var sectionsForEachPair = formatFile();
            var count = 0;
            foreach (var sections in sectionsForEachPair)
            {
                if (sections[0].All(i => sections[1].Contains(i)))
                {
                    count++;
                    continue;
                }
                else if (sections[1].All(i => sections[0].Contains(i)))
                {
                    count++;
                    continue;
                }        
            }
            return count;
        }

        public static int getNumberOfOverlapingSections()
        {
            var sectionsForEachPair = formatFile();
            int count = 0;
            foreach (var sections in sectionsForEachPair)
            {
                if (sections[0].Intersect(sections[1]).Count() > 0)
                    count++;
            }
            return count;
        }
    }
}
