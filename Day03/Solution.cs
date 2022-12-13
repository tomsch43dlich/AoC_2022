using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day03
{
    public static class Solution
    {
        private static List<List<List<char>>> FormatFile()
        {
            List<List<List<char>>> rucksack = new();
            string[] lines = File.ReadAllLines(@"D:\AoC\2022_C#\AdventOfCode2022\Day03\File.txt");

            foreach (string line in lines)
            {
                List<List<char>> compartments = new();
                List<char> temp = line.ToCharArray().ToList();
                
                compartments.Add(temp.Take((temp.Count + 1) / 2).ToList());  // first compartments
                compartments.Add(temp.Skip((temp.Count + 1) / 2).ToList());  // second compartments

                rucksack.Add(compartments);

            }
            return rucksack;
        }

        private static List<List<char>> FormatFile2()
        {
            List<List<char>> rucksack = new();
            string[] lines = File.ReadAllLines(@"D:\AoC\2022_C#\AdventOfCode2022\Day03\File.txt");

            foreach (string line in lines)
            {
                List<char> temp = line.ToCharArray().ToList();
                rucksack.Add(temp);

            }
            return rucksack;
        }

        private static int ItemToPrio(char item)
        {
            if (Char.IsUpper(item))
            {
                return ((int)item) - 38;
          
            }
            else
            {
                return ((int)item) - 96;
            }
        }

        public static int GetSumOfPrioItems()
        { 
            var rucksacks = FormatFile();
            List<int> prioList = new();

            foreach (var compartments in rucksacks)
            {
                var firstCompartment = compartments[0];
                var secondCompartment = compartments[1];

                var intersectItem = firstCompartment.Intersect(secondCompartment);

                foreach (var item in intersectItem)
                {
                    prioList.Add(ItemToPrio(item));
                }
            }
            return prioList.Sum();
        }

        public static int GetSumOfElvGroupPrioItem()
        {
            var rucksacks = FormatFile2();
            List<int> prioList = new();

            for (int i = 0; i < rucksacks.Count; i = i+3)
            {
                var intersectItem = rucksacks[i].Intersect(rucksacks[i + 1]).Intersect(rucksacks[i + 2]);
                foreach (var item in intersectItem)
                {
                    prioList.Add(ItemToPrio(item));
                }
            }
            return prioList.Sum();
        }
    }
}
