using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VS.Assessment.Process
{

    //In C#, write a program that parses a sentence and replaces each word with the following: 
    //first letter, number of distinct characters between first and last character, and last letter.  
    //For example, Smooth would become S3h.  
    //Words are separated by spaces or non-alphabetic characters and 
    //these separators should be maintained in their original form and location in the answer. 
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the input string to parse: ");
            string input =  Console.ReadLine();

            var result = SentenceParser(input);
            
            Console.WriteLine(result);
            Console.ReadLine();
        }       
        
        public static string SentenceParser(string input)
        {
            try
            {
                //Check boundary conditions
                if (string.IsNullOrEmpty(input)) { return string.Empty; }
                if (input.Length == 1) { return input; }

                //Design a regex to accept only alphabets in the sentence
                string pattern = "[^A-Za-z]";

                //Design a regex to get all the seperators in the sentence
                string seperatorPattern = "[A-Za-z]+";

                // split the input based on regex
                string[] inputArray = Regex.Split(input, pattern);
                string[] seperators = Regex.Split(input, seperatorPattern);

                int count = 0;
                StringBuilder sb = new StringBuilder();
                foreach (string item in inputArray)
                {
                    //get the first character and last character this will not change in result set.
                    char first = item[0];
                    char last = item[item.Length - 1];

                    //Hashset is used to get the distinct characters between the first and last characters. 
                    HashSet<char> uniqueChars = new HashSet<char>();

                    for (int i = 1; i < item.Length - 1; i++)
                    {
                        uniqueChars.Add(item[i]);
                    }

                    //finally append the result to the string builder
                    sb.Append(seperators[count] + (first + uniqueChars.Count().ToString() + last));

                    count++;
                }

                return sb.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception occured while sentence parsing:{exception.Message}");
                return string.Empty;
            }
            
        }


        //public static string SentenceParser(string input)
        //{
        //    string result = string.Empty;

        //    var inputArray = input.Split(' ');

        //    foreach (string item in inputArray)
        //    {
        //        char first = item[0];
        //        char last = item[item.Length - 1];

        //        var item1 = item.Remove(0, 1);
        //        var item2 = item1.Remove(item1.Length - 1, 1);

        //        result = result + (first + item2.Distinct().Count().ToString() + last) + ' ';
        //    }

        //    return result;
        //}
    }
}
