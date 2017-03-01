using System;
using System.IO;

namespace CodeJamForWomen2016
{
    /// <summary>
    /// Solution to Polynesiaglot
    /// </summary>
    class ProblemC
    {/// <summary>
     /// This solution is very efficient and can solve both small and large inputs
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
                string[] numbers = reader.ReadLine().Split(' '); // The line of parameters C,V,L is read and split
                int consonants = int.Parse(numbers[0]);
                int vowels = int.Parse(numbers[1]);
                int length = int.Parse(numbers[2]);
                // Input of a case completed

                // long result = Count(consonants, vowels, length); is used for recursion that works for small inputs but not for the large one
                long result = CountWithArray(consonants, vowels, length); 
                // Calculation of soluton completed
                writer.WriteLine("Case #{0}: {1}", i, string.Join(" ", result));
                // Solution of case written to file
            }

            writer.Close();
            reader.Close();
        }

        /// <summary>
        /// Recursive algorithm that counts words
        /// </summary>
        private static long Count(long consonants, long vowels, int length)
        {
            if (length == 1)
                return vowels % 1000000007; // Since we can't use a consonant on a one letter word
            if (length == 2)
                return (consonants * vowels + vowels * vowels) % 1000000007; // We may use a consonant and a vowel, or 2 vowels

            // If we start a word of length L with a vowel, the rest of the word is a valid word in the langauge of length L - 1
            // If we start a word with a consonant, the following letter must be a vowel, and the rest of the word is a valid word of length L - 2
            return (vowels * Count(consonants, vowels, length - 1) + consonants * vowels * Count(consonants, vowels, length - 2)) % 1000000007;
        }

        /// <summary>
        /// An iterative "dynamic programming" algorithm that is much more efficient then the recursion
        /// </summary>
        private static long CountWithArray(long consonants, long vowels, int length)
        {
            if (length == 1) // This algorithm only works for length > 1, so we handle this case seperately
                return vowels % 1000000007; 
            long[] array = new long[length + 1]; // The array will store all previous values, and save precious recursion time
            array[1] = vowels % 1000000007; // Since we can't use a consonant on a one letter word
            array[2] = (consonants * vowels + vowels * vowels) % 1000000007; // We may use a consonant and a vowel, or 2 vowels
            for (int i = 3; i <= length; i++)
            {
                // If we start a word of length L with a vowel, the rest of the word is a valid word in the langauge of length L - 1
                // If we start a word with a consonant, the following letter must be a vowel, and the rest of the word is a valid word of length L - 2
                array[i] = (vowels * array[i - 1] + consonants * vowels * array[i - 2]) % 1000000007;
            }
            // Return the last entry of the array
            return array[length];
        }
    }
}
