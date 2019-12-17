using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace StringExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            List<string> stringList = new List<string> {
                "Multiple", 
                "Multiple5.", 
                "FiRsTfiveuppercase", 
                "endsWithaHyphen.-", 
                "stringToAppend", 
                "everyoption-----TeST", 
                "anotherStringToAppend"
            };
            StringCheck stringCheck = new StringCheck();
            stringCheck.CheckStrings(stringList);
            Console.ReadLine();
        }
    }
}
