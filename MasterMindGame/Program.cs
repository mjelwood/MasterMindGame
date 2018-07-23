using System;
using System.Linq;
using System.Text;

namespace MasterMindGame
{


    //Quesitons: 
    //What do you want the result to be if user correctly guessed the number? What message to display?
    //What is the specific message you want if they lost? The requirements just say you have lost.
    //What functionality do you want if the guesses are out of bounds (Not between 1 and 6). Assumption is invalidate the entire guess and make them do it again
    //What error message should you return if the numbers are not between 1 and 6
    //After the game is complete, should we stop the game or should we add a play again workflow?
    //TODO: Refactor and break stuff out into helper and utility classes
    //TODO: Add unit Tests and look into making methods internal or even public.
    //TODO: Write Scenario's for testing

    class Program
    {
        /// <summary>
        /// Total Length the Random Number we will guess will be
        /// </summary>
        private static readonly int MaxLengthOfGuess = 4;

        /// <summary>
        /// Number of attempts the user has to guess the Number
        /// </summary>
        private static int NumberOfAttempts = 10;

        /// <summary>
        /// Main Program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("**Play Master-Mind Game***\n");
            Console.WriteLine("We generated a random 4-digit number. The possible values are between the numbers 1 to 6.\n");

            PlayMasterMind();

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

        /// <summary>
        /// Compare Generated Number and User Guess and show + or - or blank. 
        /// + if digit is correct and in proper position
        /// - if digit is correct but in wrong position
        /// blank if digit is bad
        /// </summary>
        /// <param name="solutionResult"></param>
        /// <param name="userGuess"></param>
        /// <returns>True if all solution matches the Users Guess false, if any do not match</returns>
        private static bool CompareUserGuessToGeneratedNumber(int[] solutionResult, int[] userGuess)
        {
            bool matches = false;
            var matchCount = 0;

            StringBuilder result = new StringBuilder();
            result.Append("|");

            for (int i = 0; i < solutionResult.Length; i++)
            {
                if (solutionResult[i] == userGuess[i])
                {
                    result.Append("+");
                    matchCount++;
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

            if(matchCount == 4)
            {
                matches = true;
            }

            result.Append("|");
            Console.WriteLine("Results: " + result);
            return matches;
        }

        /// <summary>
        /// Main Helper method that contains the logic to execute the mastermind game
        /// </summary>
        private static void PlayMasterMind()
        {
            int[] solutionResult = GenerateRandomNumbers();

            bool bWon = false;

            //Loop needs to keep track of attempts and if the user guessed correctly.
            for (int i = NumberOfAttempts; i > 0 && !bWon; i--)
            {
                Console.WriteLine("\nEnter your guess ({0} guesses remaining)", i);
                var userGuess = ReadAndValidateUserGuess(MaxLengthOfGuess);

                if (CompareUserGuessToGeneratedNumber(solutionResult, userGuess))
                {
                    bWon = true;
                }
            }

            if (bWon)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("You lost.");
            }

            //Console.Write("The correct number is: ");
            //for (int j = 0; j < MaxLengthOfGuess; j++)
            //{
            //    Console.Write(solutionResult[j]);
            //}
        }

        /// <summary>
        /// Read and validation to check if user guess is between 1 and 6 and is 4 numbers in length
        /// </summary>
        /// <param name="userGuessLength"></param>
        /// <returns>Int Array of the User Guess</returns>
        private static int[] ReadAndValidateUserGuess(int userGuessLength)
        {
            var validInput = false;
            int[] userGuess = new int[userGuessLength];

            do
            {
                bool invalidNumber = false;
                string input = Console.ReadLine();

                if (input.Length != 4)
                {
                    Console.Write("Invalid Length\n");
                }
                else
                {
                    var charArray = input.ToCharArray();

                    //TODO: Look to convert to method to make testing easier. Util class? Unit testing can be made much simpler by refactoring this
                    foreach (char validateToInt in charArray)
                    {
                        if (!int.TryParse(validateToInt.ToString(), out int number))
                        {
                            invalidNumber = true;
                            break;
                        }

                        //Number must be between 1-6
                        if (number > 6 || number < 1)
                        {
                            invalidNumber = true;
                            break;
                        }
                    }

                    if (!invalidNumber)
                    {
                        userGuess = charArray.Select(c => Convert.ToInt32(c.ToString())).ToArray();

                        validInput = true;
                    }
                    else
                    {
                        Console.Write("Invalid Input Try Again\n");
                    }
                }
            }
            while (!validInput);

            return userGuess;
        }
    }
}
