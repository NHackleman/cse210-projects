using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        Console.WriteLine($"I'm thinking of a number between 1 and 100. Can you guess it?");

        while (true)
        {
            Console.Write("What is your guess? ");
            int guess = Convert.ToInt32(Console.ReadLine());

            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                break;
            }
        }
    }
}