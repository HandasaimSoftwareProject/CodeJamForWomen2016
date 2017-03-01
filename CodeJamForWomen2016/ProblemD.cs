using System;
using System.IO;
using System.Collections.Generic;

namespace CodeJamForWomen2016
{
    /// <summary>
    /// Solution to Password Security
    /// </summary>
    class ProblemD
    {
        const int NUMBER_OF_ATTEMPTS = 10000;

        /// <summary>
        /// This solution is very efficient and can solve both small and large inputs.
        /// The solution is, however, random, and has a small chance of failing.
        /// </summary>
        /// <param name="filename">The name of the input file, without extension (.in)</param>
        public static void Solve(string filename)
        {
            string inputFile = "..\\..\\Inputs\\" + filename + ".in";
            string outputFile = "..\\..\\Outputs\\" + filename + ".out";
            StreamReader reader = new StreamReader(inputFile);
            StreamWriter writer = new StreamWriter(outputFile);
            int numberOfCases = int.Parse(reader.ReadLine()); // That's the number T from the problem description
            for (int i = 1; i <= numberOfCases; i++) // Inputting each case
            {
                int wordCount = int.Parse(reader.ReadLine()); // That's the number N from the problem description
                string[] words = reader.ReadLine().Split(' '); // The line of words is splitted
                // Input of a case completed
                string result = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // A starter string
                Random r = new Random();
                for(int j = 0; j < NUMBER_OF_ATTEMPTS && ContainsWord(result, words); j++) // Run for a fixed amount of iterations or until a valid result is found
                {
                    result = Randomize(result, r);
                }
                if (ContainsWord(result, words)) // If the last string contains any word
                    result = "IMPOSSIBLE"; // Then it is probably impossible
                // Calculation of soluton completed
                writer.WriteLine("Case #{0}: {1}", i, string.Join(" ", result));
                // Solution of case written to file
            }

            writer.Close();
            reader.Close();
        }

        /// <summary>
        /// This helper method checks if our string contain any of the words in the given array
        /// </summary>
        private static bool ContainsWord(string str, string[] words)
        {
            foreach (string word in words)
                if (str.Contains(word))
                    return true;
            return false;
        }

        /// <summary>
        /// This helper method returns a a "shuffle" of the given string (a random permutation of the letters)
        /// </summary>
        private static string Randomize(string str, Random r)
        {
            List<char> list = new List<char>(str);
            string result = "";
            while(list.Count > 0)
            {
                int index = r.Next(list.Count);
                result += list[index];
                list.RemoveAt(index);
            }
            return result;
        }
    }
}
