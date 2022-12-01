using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;

namespace Puzzle1
{
    class Program
    {
        static void Main(string[] args)
        {

            Answer1();
            Answer2();
            Console.ReadLine();
        }

        public static void Answer1()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\NileshRaut\Desktop\Puzzle1_Input.txt");

            var timer = new Stopwatch();
            timer.Start();
            int calories = 0;
            int number = 1;
            var food = new List<int>();
            List<Elf> elfs = new List<Elf>();
            foreach (var line in lines)
            {
                //Line break
                if (line == Environment.NewLine || line == string.Empty)
                {
                    Elf elf = new Elf();
                    elf.number = number;
                    elf.foods = food;
                    elf.TotalCalorie = calories;
                    elfs.Add(elf);

                    food = new List<int>();
                    calories = 0;
                    number++;
                }
                else
                {
                    food.Add(Convert.ToInt32(line));
                    calories = calories + Convert.ToInt32(line);
                }
            }

            int maxcalorie = elfs.Max(t => t.TotalCalorie);
            var answer1Time = timer.ElapsedMilliseconds;

            timer.Restart();

            int max3 = elfs.OrderByDescending(x => x.TotalCalorie).Take(3).Select(x => x.TotalCalorie).Sum();
            var answer2Time = timer.ElapsedMilliseconds;
            Console.WriteLine($"Answer1 = {maxcalorie}; Time Taken = {answer1Time}ms");
            Console.WriteLine($"Answer2 = { max3}; Time Taken = {answer2Time}ms");

          
            //var maxelf = elfs.FirstOrDefault(x => x.TotalCalorie == maxcalorie);
        }

        public static void Answer2()
        {
            Console.WriteLine("Day 01!");
            //string inputFile = @"..\..\..\sample_input.txt";
            string inputFile = @"C:\Users\NileshRaut\Desktop\Puzzle1_Input.txt";
            var input = File.ReadAllLines(inputFile).ToList();
            var timer = new Stopwatch();
            timer.Start();
            var elves = new List<int>();
            var calories = 0;
            var elfCounter = 1;
            for (var i = 0; i < input.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                {
                    elves.Add(calories);
                    calories = 0;
                    elfCounter++;
                    continue;
                }
                calories += int.Parse(input[i]);
            }
            var answer1 = elves.Max();
            var answer1Time = timer.ElapsedMilliseconds;
            timer.Restart();
            var answer2 = elves.OrderByDescending(z => z).Take(3).Sum();
            var answer2Time = timer.ElapsedMilliseconds;
            Console.WriteLine($"Answer1 = {answer1}; Time Taken = {answer1Time}ms");
            Console.WriteLine($"Answer2 = { answer2}; Time Taken = {answer2Time}ms");

        }

    }




    class Elf
    {
        public int number { get; set; }
        public List<int> foods { get; set; }
        public int TotalCalorie { get; set; }
    }
}
