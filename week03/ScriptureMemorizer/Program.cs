using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", "3", "16");
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son");

        while (true)
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWords();
        }
    }
}