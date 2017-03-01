using System;
using System.IO; // Important! Needed for file input/output
using System.Collections.Generic; // Because I need the Queue class

namespace CodeJamForWomen2016
{
    /// <summary>
    /// Solution to Cody's Jams
    /// </summary>
    class ProblemA
    {
        /// <summary>
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
            for(int i = 1; i <= numberOfCases; i++) // Inputting each case
            {
                int numberOfPrices = int.Parse(reader.ReadLine()); // That's the number N from the problem description
                string[] stringLabels = reader.ReadLine().Split(' '); // The line of lables is read and split by spaces
                int[] labels = new int[2 * numberOfPrices]; // Labels will be converted into string and inserted into to this array
                for (int j = 0; j < labels.Length; j++)
                {
                    labels[j] = int.Parse(stringLabels[j]);
                }
                // Input of a case completed
                List<int> prices = new List<int>(); // Will hold the result (sale prices)
                Queue<int> queue = new Queue<int>(); // Will hold all expected non sale prices
                for(int j = 0; j < labels.Length; j++)
                {
                    if (queue.Count > 0 && queue.Peek() == labels[j]) // If the current label is the equals the first label in the queue
                    {
                        queue.Dequeue(); // Then we only have to remove it from the queue, since we have already seen it's paired sale price
                    }
                    else // if it is not the first in the queue
                    {
                        prices.Add(labels[j]); // it's a new sale price, and we add it to the result list
                        queue.Enqueue(labels[j] / 3 * 4); // and add the pre-sale price to the queue, so that we can identify it when we see it in the labels array
                    }
                }
                // Calculation of soluton completed
                writer.WriteLine("Case #{0}: {1}", i, string.Join(" ", prices));
                // Solution of case written to file
            }

            writer.Close();
            reader.Close();
        }
    }
}
