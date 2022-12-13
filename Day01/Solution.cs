using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day01
{
    public static class Solution
    {
        private static List<List<int>> formatFile()
        {
            List<List<int>> list = new List<List<int>>();
            string[] lines = File.ReadAllLines(@"D:\AoC\2022_C#\AdventOfCode2022\Day01\File.txt");

            List<int> temp = new List<int>();
            foreach (string line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    list.Add(new List<int>(temp));
                    temp.Clear();
                }
                else
                    temp.Add(Convert.ToInt32(line));
            }
            list.Add(new List<int>(temp));
            return list;
        } 
        private static List<int> getSumCaloriesList()
        {
            List<List<int>> elvCalorieList = formatFile();
            List<int> sumCalories = new List<int>();
            foreach (List<int> calorieList in elvCalorieList)
            {
                sumCalories.Add(calorieList.Sum());
            }
            return sumCalories;
        }

        public static int getMaxCaloriesFromElves()
        {  
            return getSumCaloriesList().Max();
        }

        public static int getFirstThreeMaxCaloriesFromElves()
        {
            var sumCalories = getSumCaloriesList();
            int[] threeMaxCalories = new int[3];
            int counter = 0;
            while (counter != 3)
            {
                threeMaxCalories[counter] = sumCalories.Max();
                sumCalories.Remove(threeMaxCalories[counter]);
                counter++;
            }
            return threeMaxCalories.Sum();
        
        }
    }
}
