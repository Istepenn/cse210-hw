using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    // Class to represent a journal entry
    class JournalEntry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        // Constructor to initialize a journal entry with prompt, response, and date
        public JournalEntry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }

        // Method to display the journal entry
        public void DisplayEntry()
        {
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Prompt: {Prompt}");
            Console.WriteLine($"Response: {Response}");
            Console.WriteLine();
        }
    }

    // Class to represent the journal
    class Journal
    {
        private List<JournalEntry> entries;

        // Constructor to initialize the journal
        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        // Method to write a new entry
        public void WriteNewEntry()
        {
            string[] prompts = {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            // Select a random prompt
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Length)];

            Console.WriteLine($"Prompt: {prompt}");

            // Get response from user
            Console.Write("Enter your response: ");
            string response = Console.ReadLine();

            // Get current date
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            // Create a new journal entry
            JournalEntry entry = new JournalEntry(prompt, response, date);

            // Add the entry to the list of entries
            entries.Add(entry);
        }

        // Method to display the journal
        public void DisplayJournal()
        {
            foreach (var entry in entries)
            {
                entry.DisplayEntry();
            }
        }

        // Method to save the journal to a file
        public void SaveJournalToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }

            Console.WriteLine("Journal saved successfully!");
        }

        // Method to load the journal from a file
        public void LoadJournalFromFile(string filename)
        {
            entries.Clear(); // Clear existing entries

            string line;
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        entries.Add(new JournalEntry(parts[1], parts[2], parts[0]));
                    }
                }
            }

            Console.WriteLine("Journal loaded successfully!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        journal.WriteNewEntry();
                        break;
                    case 2:
                        journal.DisplayJournal();
                        break;
                    case 3:
                        Console.Write("Enter the filename to save: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveJournalToFile(saveFilename);
                        break;
                    case 4:
                        Console.Write("Enter the filename to load: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadJournalFromFile(loadFilename);
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
