using System;
using System.IO;

namespace CodeJamForWomen2016
{
    /// <summary>
    /// Solution to Dance Around The Clock
    /// </summary>
    class ProblemB
    {
        /// <summary>
        /// This solution is relatively simple, and will only solve the small input
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
                string[] numbers = reader.ReadLine().Split(' '); // The line of parameters D,K,N is read and split
                int dancers = int.Parse(numbers[0]);
                int dancer = int.Parse(numbers[1]);
                int turns = int.Parse(numbers[2]);
                // Input of a case completed
                int[] circle = new int[dancers]; // The circle of cancers
                for (int j = 0; j < dancers; j++) // Initializing to starting position
                {
                    circle[j] = j + 1;
                }

                for (int t = 0; t < turns; t++) // Simulating every turn
                {
                    for (int k = t % 2; k < dancers; k += 2) // the initialization of k makes the loop act differently for even and odd turns
                    {
                        int temp = circle[k]; // Swapping adjecent cells
                        circle[k] = circle[(k + 1) % dancers];
                        circle[(k + 1) % dancers] = temp;
                    }
                }
                int dancerIndex = Array.IndexOf(circle, dancer); // Finding our dancer after the simulation
                int left = circle[(dancerIndex + 1) % dancers]; // and checking what's on his left
                int right = circle[(dancerIndex - 1 + dancers) % dancers]; // and what's on his right
                // Calculation of soluton completed
                writer.WriteLine("Case #{0}: {1} {2}", i, left, right);
                // Solution of case written to file
            }
            writer.Close();
            reader.Close();
        }

    }
}
