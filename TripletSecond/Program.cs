using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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

        private static Array GetTripletsWithBuilder(string text)
        {
            List<StringBuilder> list = new List<StringBuilder>();
            StringBuilder triplet = new StringBuilder(3);
            int counter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                counter++;
                if (char.IsLetter(text[i]))
                {
                    triplet.Append(text[i]);
                    if (triplet.Length==3)
                    {
                        list.Add(triplet);
                        triplet.Remove(0, 2);
                        i -= 2;
                    }
                }
                else
                {
                    triplet.Remove(0, 2);;
                }
                
            }
            Console.WriteLine(list.Count);
            Console.WriteLine(counter);
            return list.ToArray();
        }
        
        private static Array GetTripletsFromArray(string text)
        {
            var textArray = text.ToArray();
            var tripletArray = new char[3];
            // var tripletArrayCopy = new char[3];
            // char[,] allTripletsArray = new char[30000,3];
            Dictionary<char[], uint> tripletDictionary = new Dictionary<char[], uint>();
            // HashSet<string> hashSetOfTriplets = new HashSet<string>();
            foreach (var letter in textArray)
            {
                if (char.IsLetter(letter))
                {

                    tripletArray[0] = tripletArray[1];
                    tripletArray[1] = tripletArray[2];
                    tripletArray[2] = letter;
                    // tripletArray.CopyTo(tripletArrayCopy, 0);
                    // tripletArrayCopy.Clone() = tripletArray;
                    // tripletArrayCopy = (char[]) tripletArray.Clone();
                    if (tripletArray[2] != 0 && tripletArray[1] != 0 && tripletArray[0] != 0)
                    {
                        // bool dded = hashSetOfTriplets.Add(tripletArray.ToString());
                        if (tripletDictionary.ContainsKey(tripletArray) is false)
                        {
                            tripletDictionary.Add((char[]) tripletArray.Clone(), 1);
                            // Console.WriteLine("{0}{1}{2}", tripletArray[0], tripletArray[1], tripletArray[2]);

                        }
                        else
                        {
                            tripletDictionary[tripletArray]++;
                        }
                    }
                }
                else
                {
                    // Array.Clear(tripletArray, 0, 3);
                    tripletArray = new char[3];
                    // Console.WriteLine(tripletArray.Length);
                }
            }

            foreach (var item in tripletDictionary)
            {
                Console.WriteLine("{0}{1}{2} - {3}", item.Key[0],item.Key[1],item.Key[2], item.Value);
            }
            Console.WriteLine(tripletDictionary.Count);
            return tripletArray;

            // List<string> list = new List<string>();
            // string triplet = "";
            // int counter = 0;
            // for (int i = 0; i < textArray.Length; i++)
            // {
            //     counter++;
            //     if (char.IsLetter(textArray[i]))
            //     {
            //         triplet += textArray[i];
            //         if (triplet.Length==3)
            //         {
            //             list.Add(triplet);
            //             triplet = "";
            //             i -= 2;
            //         }
            //     }
            //     else
            //     {
            //         triplet = "";
            //     }
            //     
            // }
            // Console.WriteLine(list.Count);
            // Console.WriteLine(counter);
            // return list.ToArray();
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
            string text = File.ReadAllText("G:/CSharpProjects/TripletSecond/TripletSecond/2.txt").ToUpper(); 
            Array array = GetTripletsWithBuilder(text);
            Dictionary<string, int> tripletDictionary = CountTriplets(array);
            PrintTriplets(tripletDictionary);
            PrintTime(stopWatch);
            
        }
    }
}