using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindGame
{


    //Quesitons: 
    //What do you want the result to be if user correctly guessed the number? What message to display?


    class Program
    {
        /// <summary>
        /// Total Length the Random Number we will guess will be
        /// </summary>
        private static readonly int MaxLengthOfGuess = 4;

        public static void Main(string[] args)
        {
            Console.WriteLine("**Play Master-Mind Game***\n");
            Console.WriteLine("We generated a random 4-digit number. The possible values are between the numbers 1 to 6.\n");

            int[] test = GenerateRandomNumbers();

            int[] userTest = { 1, 2, 3, 4 };

            CompareUserGuessToGeneratedNumber(test, userTest);

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

        private static void CompareUserGuessToGeneratedNumber(int[] solutionResult, int[] userGuess)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < solutionResult.Length; i++)
            {
                if (solutionResult[i] == userGuess[i])
                {
                    result.Append("+");
                }
                else if (solutionResult.Contains(userGuess[i]))
                {
                    //Does solution contain the current digit in user guess?
                    result.Append("-");
                }
                else
                {
                    result.Append(" ");
                }
            }

            Console.WriteLine("Results: " + result);        
        }
    }
}
