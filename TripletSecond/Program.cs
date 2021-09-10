using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace TripletSecond
{
    class Program
    {
        private static Array GetTriplets(string text)
        {
            List<string> list = new List<string>();
            string triplet = "";
            int counter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                counter++;
                if (char.IsLetter(text[i]))
                {
                    triplet += text[i];
                    if (triplet.Length==3)
                    {
                        list.Add(triplet);
                        triplet = "";
                        i -= 2;
                    }
                }
                else
                {
                    triplet = "";
                }
                
            }
            Console.WriteLine(list.Count);
            Console.WriteLine(counter);
            return list.ToArray();
        }

        private static Dictionary<string,int> CountTriplets(Array tripletArray)
        {
            Dictionary<string, int> tripletDictionary = new Dictionary<string, int>();
            foreach (string triplet in tripletArray)
            {
                if (tripletDictionary.ContainsKey(triplet))
                {
                    tripletDictionary[triplet]++;
                }
                else
                {
                    tripletDictionary.Add(triplet, 1);
                }
            }

            return tripletDictionary;
        }
        
        private static void PrintTime(Stopwatch timer)
        {
            TimeSpan ts = timer.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        private static void PrintTriplets(Dictionary<string, int> tripletDictionary)
        {
            foreach (var pair in tripletDictionary.OrderByDescending(pair => pair.Value))
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
        
        static void Main(string[] args)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            string text = File.ReadAllText("G:/CSharpProjects/TripletSecond/TripletSecond/1.txt").ToUpper(); 
            Array array = GetTriplets(text);
            Dictionary<string, int> tripletDictionary = CountTriplets(array);
            PrintTriplets(tripletDictionary);
            PrintTime(stopWatch);
            
        }
    }
}