using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day11
{
    public static class Solution
    {
        
        private class Monkey
        {
            public List<int> Items { get; set; }
            public Func<int, int> Operation { get; set; }
            public int TestNumber { get; set; }
            public Dictionary<bool, int> TestOperation { get; set; }
            public int InspectedItems { get; set; } = 0;
        }

        private static List<Monkey> GetMonkysFromFile()
        {
            List<Monkey> monkys = new List<Monkey>();
            var MonkeyTextList = File.ReadAllText(@"D:\AoC\2022_C#\AdventOfCode2022\Day11\File.txt").Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var monkeyText in MonkeyTextList)
            {
                Regex regexNumber = new Regex(@"\d\d?");

                List<string> monkeyTextContent = monkeyText.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

                List<int> startingItems = regexNumber.Matches(monkeyTextContent[1]).Select(x => Convert.ToInt32(x.Value)).ToList();
                Func<int, int> operation = getOperation(monkeyTextContent[2]);
                int testNr = Convert.ToInt32(regexNumber.Match(monkeyTextContent[3]).Value);
                Dictionary<bool, int> testOperation = getTestOperation(Convert.ToInt32(regexNumber.Match(monkeyTextContent[4]).Value), Convert.ToInt32(regexNumber.Match(monkeyTextContent[5]).Value));
                
                monkys.Add(new Monkey()
                {
                    Items = startingItems,
                    Operation = operation,
                    TestNumber = testNr,
                    TestOperation = testOperation
                }) ;
            }
            return monkys;
        }

        private static Func<int, int> getOperation(string operationText)
        {
            string[] operationItem = operationText.Split(" ");
            string operationValue = operationItem[5];
            string operationOperator = operationItem[4];
            Func<int, int> operation;
            if (operationValue == "old" )
                switch (operationOperator)
                {
                    case "+": return operation = x => x + x;
                    case "*": return operation = x => x * x;
                    default: return null;
                }
            else
            {
                int value = Convert.ToInt32(operationValue);
                switch (operationOperator)
                {
                    case "+": return operation = x => x + value;
                    case "*": return operation = x => x * value;
                    default: return null;
                }
            } 
        }
        private static Dictionary<bool, int> getTestOperation(int trueNr, int falseNr)
        {
            Dictionary<bool, int> testOperations = new()
            {
                {true, trueNr },
                {false, falseNr}
            };
            return testOperations;
        }


        public static int GetMonkeyBusiness()
        {
            var monkeys = GetMonkysFromFile();

            for (int i = 0; i < 20; i++)
            {
                foreach (var monkey in monkeys)
                {
                    foreach (var item in monkey.Items)
                    {
                        monkey.InspectedItems++;
                        var _new = monkey.Operation(item);
                        _new = (int)(_new / 3);
                        monkeys[monkey.TestOperation[_new % monkey.TestNumber == 0]].Items.Add(_new);       
                    }
                    monkey.Items.Clear();
                }
            }
            int result = 1;
            var test = monkeys.OrderByDescending(x => x.InspectedItems).Take(2).ToList();
            foreach (var i in test)
            {
                result *= i.InspectedItems;
            }
            return result;
        }
    }
}
