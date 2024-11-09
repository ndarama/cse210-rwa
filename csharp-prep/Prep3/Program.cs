using System;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                // Generate a random number between 1 and 100 (inclusive)
                Random random = new Random();
                int magicNumber = random.Next(1, 101);   


                int guessCount = 0; // Track the number of guesses

                Console.WriteLine("Welcome to Guess My Number!");

                while (true)
                {
                    guessCount++;

                    Console.Write("What is your guess? ");
                    int guess = int.Parse(Console.ReadLine());

                    if (guess == magicNumber)
                    {
                        Console.WriteLine($"You guessed it in {guessCount} tries! Congratulations!");
                        break;
                    }
                    else if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher!");
                    }
                    else
                    {
                        Console.WriteLine("Lower!");
                    }
                }

                Console.Write("Play again? (yes/no): ");
                string answer = Console.ReadLine().ToLower();

                playAgain = answer == "yes";
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}