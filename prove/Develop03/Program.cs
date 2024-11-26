using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List of scriptures
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 3, 6), "Trust in the Lord with all your heart and lean not on your own understanding."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."),
            new Scripture(new Reference("Isaiah", 41, 10), "So do not fear, for I am with you; do not be dismayed, for I am your God."),
            new Scripture(new Reference("Romans", 8, 28), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose.")
        };

        // Randomly select a scripture
        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

        // Start memorization
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        while (!selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input?.ToLower() == "quit")
                break;

            selectedScripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine("Congratulations! You have memorized the scripture:");
        Console.WriteLine(selectedScripture.GetDisplayText());
    }
}
/* Enhancements to Exceed Requirements:
    
    1. Support for Multiple Scriptures:
       - The program supports a library of 5 scriptures instead of a single scripture.
       - Scriptures are randomly selected at the start of the program, adding variety and replayability.

    2. Enhanced User Experience:
       - Added formatting to improve readability, such as separating the scripture text and reference with line breaks.
       - Included helpful messages like "All words hidden! Congratulations!" at the end.

    3. Structured Code for Extensibility:
       - The code is modular, with encapsulated classes for `Word`, `Reference`, and `Scripture`.
       - It’s easy to add new features or extend functionality, such as loading scriptures from a file.

    These enhancements make the program more engaging, interactive, and user-friendly, ensuring it goes beyond the basic requirements.
*/