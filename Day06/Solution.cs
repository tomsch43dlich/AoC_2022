using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day06
{
    public static class Solution
    {
        private static string formatFile()
        {
            return File.ReadAllText(@"D:\AoC\2022_C#\AdventOfCode2022\Day06\File.txt");
            
        }

        private static bool checkIfAllElementAreDiffrent(Queue<char> queue)
        {
            var set = queue.ToHashSet();
            if (set.Count() == 4)
            {
                return true;
            }
            return false;
        }
        private static bool checkIfAllElementAreDiffrent2(Queue<char> queue)
        {
            var set = queue.ToHashSet();
            if (set.Count() == 14)
            {
                return true;
            }
            return false;
        }

        public static int GetFirstIndexOfFirstMarker()
        {
            string datastream = formatFile();
            Queue<char> starterPack = new Queue<char>();
            for (int i = 0; i < 4; i++)
            {
                starterPack.Enqueue(datastream.ElementAt(i));
            }
            int counter = 4;
            while(!checkIfAllElementAreDiffrent(starterPack))
            {
                starterPack.Dequeue();
                starterPack.Enqueue(datastream.ElementAt(counter));
                counter++;
            }
            return counter;
        }
        public static int GetFirstIndexOfFirstMarker2()
        {
            string datastream = formatFile();
            Queue<char> starterPack = new Queue<char>();
            for (int i = 0; i < 14; i++)
            {
                starterPack.Enqueue(datastream.ElementAt(i));
            }
            int counter = 14;
            while (!checkIfAllElementAreDiffrent2(starterPack))
            {
                starterPack.Dequeue();
                starterPack.Enqueue(datastream.ElementAt(counter));
                counter++;
            }
            return counter;
        }
    }
}
