using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace AdventOfCode2022
{
    class AdventOfCode2022
    {
        public enum Day
        {
            DAY1,
            DAY2,
            DAY3,
            DAY4,
            DAY5,
            DAY6,
            DAY7,
            DAY8,
            DAY9,
            DAY10,
            DAY11,
            DAY12,
            DAY13,
            DAY14,
            DAY15,
            DAY16,
            DAY17,
            DAY18,
            DAY19,
            DAY20,
                
            DAY21,
                
            DAY22,
                
            DAY23,
            DAY24,
            DAY25
        }
        static void Main()
        {
            Day day = Day.DAY12;
            string result1 = "";
            string result2 = "";
            Stopwatch time1 = new Stopwatch();
            Stopwatch time2 = new Stopwatch();

            switch (day)
            {
                case Day.DAY1:
                    time1.Start();
                    result1 = Day01.Solution.getMaxCaloriesFromElves().ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = Day01.Solution.getFirstThreeMaxCaloriesFromElves().ToString();
                    time2.Stop();
                    break;
                case Day.DAY2:
                    time1.Start();
                    result1 = Day02.Solution.CalculateMyPointsFirstStrategie().ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = Day02.Solution.CalculateMyPointsSecondStrategie().ToString();
                    time2.Stop();
                    break;
                case Day.DAY3:
                    time1.Start();
                    result1 = Day03.Solution.GetSumOfPrioItems().ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = Day03.Solution.GetSumOfElvGroupPrioItem().ToString();
                    time2.Stop();
                    break;
                case Day.DAY4:
                    time1.Start();
                    result1 = Day04.Solution.getNumberPairWithSubSets().ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = Day04.Solution.getNumberOfOverlapingSections().ToString();
                    time2.Stop();
                    break;
                case Day.DAY5:
                    time1.Start();
                    result1 = Day05.Solution.GetCratesOnTop();
                    time1.Stop();

                    time2.Start();
                    result2 = Day05.Solution.GetCratesOnTop2();
                    time2.Stop();
                    break;
                case Day.DAY6:
                    time1.Start();
                    result1 = Day06.Solution.GetFirstIndexOfFirstMarker().ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = Day06.Solution.GetFirstIndexOfFirstMarker2().ToString();
                    time2.Stop();
                    break;
                case Day.DAY7:
                    time1.Start();
                    result1 = Day07.Solution.GetSumOfFileSize(100000).ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = Day07.Solution.FindDeletableDirectory().ToString();
                    time2.Stop();
                    break;
                case Day.DAY8:
                    time1.Start();
                    result1 = Day08.Solution.GetNumberOfVisbleTree().ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = Day08.Solution.GetHighestScenicScore().ToString();
                    time2.Stop();
                    break;
                case Day.DAY9:
                    time1.Start();
                    result1 = Day09.Solution.GetNumberOfVisitPositions().ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = Day09.Solution.GetNumberOfVisitPositionLongerRope().ToString();
                    time2.Stop();
                    break;
                case Day.DAY10:
                    time1.Start();
                    result1 = Day10.Solution.GetSumOfSignalStrength().ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = "\n"+ Day10.Solution.GetCRTImage();
                    time2.Stop();
                    break;
                case Day.DAY11:
                    time1.Start();
                    result1 = Day11.Solution.GetMonkeyBusiness().ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY12:
                    time1.Start();
                    result1 = Day12.Solution.GetLengthOfShortestPath().ToString();
                    time1.Stop();

                    time2.Start();
                    result2 = Day12.Solution.GetLengthOfShortestPath2().ToString();
                    time2.Stop();
                    break;
                case Day.DAY13:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY14:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY16:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY17:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY18:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY19:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY20:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY21:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY22:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY23:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY24:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
                case Day.DAY25:
                    time1.Start();
                    result1 = "";
                    time1.Stop();

                    time2.Start();
                    result2 = "";
                    time2.Stop();
                    break;
            }

            Console.WriteLine( String.Format
                (
                    "{0}\n" +
                    "=================================================================\n" +
                    " Part 1: {1}\t=> Time: {2}\n" +
                    " Part 2: {3}\t=> Time: {4}\n" +
                    "=================================================================\n",
                    day.ToString(), result1, time1.Elapsed, result2, time2.Elapsed

                )
            );
        }
    }
}