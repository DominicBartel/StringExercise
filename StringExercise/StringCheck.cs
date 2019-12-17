using System;
using System.Collections.Generic;
using System.Linq;

namespace StringExercise
{
    internal class StringCheck
    {
        internal List<string> ConvertedList { get; private set; }
        internal List<string> OriginalList { get; private set; }
        internal int  TotalIn { get; private set; }
        internal int MedianIn { get; private set; }
        internal int TotalOut { get; private set; }
        internal int MedianOut { get; private set; }
        internal void CheckStrings(List<string> stringList)
        {
            this.OriginalList = stringList;
            this.ConvertedList = new List<string>();

            int[] inLengths = new int[stringList.Count];
            int[] outLengths = new int[stringList.Count];

            for(int i = 0; i < OriginalList.Count; i++)
            {
                inLengths[i] = OriginalList[i].Length;
                this.TotalIn += OriginalList[i].Length;

                this.ConvertedList.Add(stringList[i]);
                this.ConvertedList[i] = MultipleOfFourConversion(this.ConvertedList[i]);
                this.ConvertedList[i] = MultipleOfFiveConversion(this.ConvertedList[i]);
                this.ConvertedList[i] = UpperCaseConversion(this.ConvertedList[i]);
                this.ConvertedList[i] = HyphenConversion(this.ConvertedList[i], i);

                outLengths[i] = ConvertedList[i].Length;
                this.TotalOut += ConvertedList[i].Length;

                Console.WriteLine(this.ConvertedList[i]);
            }

            Console.WriteLine("Final Report:");
            Console.WriteLine("Total characters for input: " + this.TotalIn);
            Console.WriteLine("Total characters for output: " + this.TotalOut);
            Console.WriteLine("Median of characters for input: " + CalculateMedian(inLengths));
            Console.WriteLine("Median of characters for output: " + CalculateMedian(outLengths));

        }

        private int CalculateMedian(int[] inLengths)
        {
            int median = 0;
            int middleLength = inLengths.Length / 2;
            var organizedLengths = inLengths.OrderBy(n => n);
            if(inLengths.Length % 2 == 0)
            {
                median = (organizedLengths.ElementAt(middleLength) + organizedLengths.ElementAt(middleLength -1)) / 2;
            }
            else
            {
                median = organizedLengths.ElementAt(middleLength);
            }

            return median;
        }

        private string HyphenConversion(string str, int location)
        {
            string convertedString = str;
            // the prompt doesn't say what to do if the list ends with the value being evaluated, 
            // so I chose to simply return the string without changes
            if (str.EndsWith("-") && this.ConvertedList.Count > location)
            {
                //I am assuming by "remove it" in the instructions the hyphen is being referred to as "it"
                //I am also assuming for the append we want to leave the existing data, both because its easier to implement and because 
                //I can't find any reason that was not the intention. If I was wrong please let me know and I can change the code
                convertedString = str.Substring(0,str.Length-1) +  this.OriginalList[location + 1]; 
            }
            return convertedString;
        }

        private string UpperCaseConversion(string str)
        {
            string convertedString = str;
            string firstFive = str.Substring(0, 5);

            if (firstFive.Count(c => char.IsUpper(c)) > 2)
            {
                convertedString = str.ToUpper();
            }
            return convertedString;
        }

        private string MultipleOfFiveConversion(string str)
        {
            string convertedString = str;
            if (str.Length % 5 == 0)
            {
                convertedString = str.Substring(0,5);
            }
            return convertedString;
        }

        private string MultipleOfFourConversion(string str)
        {
            string convertedString = str;
            if(str.Length % 4 == 0)
            {
                char[] toChar = str.ToCharArray();
                Array.Reverse(toChar);
                convertedString = new string(toChar);
            }
            return convertedString;
        }
    }
}