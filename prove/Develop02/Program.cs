using System;

public class Program
{
    public static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Program Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Entry newEntry = new Entry(prompt, response);
                    journal.AddEntry(newEntry);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename to save journal: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load journal: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}