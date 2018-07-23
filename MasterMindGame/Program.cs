using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindGame
{
    class Program
    {
        /// <summary>
        /// Total Length the Random Number we will guess will be
        /// </summary>
        private static readonly int MaxLengthOfGuess = 4;

        public static void Main(string[] args)
        {

            int[] test = GenerateRandomNumbers();

            Console.ReadLine();
        }

        /// <summary>
        /// Generate Random Number between 1 and 6
        /// </summary>
        /// <returns>A Integer array of 4 random numbers between 1 and 6</returns>
        private static int[] GenerateRandomNumbers()
        {
            int singleNumber;
            int[] randomNumber = new int[MaxLengthOfGuess];
            Random rnd = new Random();

            for (int i = 0; i < MaxLengthOfGuess; i++)
            {
                singleNumber = rnd.Next(1, 7);
                randomNumber[i] = singleNumber;
            }

            return randomNumber;
        }
    }
}
