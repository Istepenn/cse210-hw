using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Class to represent a single word in the scripture
    public class Word
    {
        public string Text { get; }
        public bool Hidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            Hidden = false;
        }

        // Method to hide the word
        public void Hide()
        {
            Hidden = true;
        }

        // Method to reset the hidden state
        public void Reset()
        {
            Hidden = false;
        }
    }

    // Class to represent the reference of a scripture
    public class ScriptureReference
    {
        public string Book { get; }
        public int StartVerse { get; }
        public int EndVerse { get; }

        public ScriptureReference(string reference)
        {
            string[] parts = reference.Split(':');
            Book = parts[0];
            string[] verses = parts[1].Split('-');
            StartVerse = int.Parse(verses[0]);
            EndVerse = verses.Length > 1 ? int.Parse(verses[1]) : StartVerse;
        }

        // Method to get the formatted reference
        public string GetFormattedReference()
        {
            if (StartVerse == EndVerse)
                return $"{Book} {StartVerse}";
            else
                return $"{Book} {StartVerse}-{EndVerse}";
        }
    }

    // Class to represent a scripture
    public class Scripture
    {
        private readonly ScriptureReference reference;
        private readonly List<Word> words;

        public Scripture(string reference, string text)
        {
            this.reference = new ScriptureReference(reference);
            words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        // Method to display the scripture
        public void Display()
        {
            Console.WriteLine($"Reference: {reference.GetFormattedReference()}");
            foreach (var word in words)
            {
                Console.Write(word.Hidden ? "___ " : word.Text + " ");
            }
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
        }

        // Method to hide a random word
        public bool HideRandomWord()
        {
            var visibleWords = words.Where(word => !word.Hidden).ToList();
            if (visibleWords.Count == 0)
                return false;

            Random rand = new Random();
            int index = rand.Next(0, visibleWords.Count);
            visibleWords[index].Hide();
            return true;
        }

        // Method to check if all words are hidden
        public bool AllWordsHidden()
        {
            return words.All(word => word.Hidden);
        }

        // Method to reset all word states
        public void ResetWordStates()
        {
            foreach (var word in words)
            {
                word.Reset();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Sample usage
            var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
            while (!scripture.AllWordsHidden())
            {
                Console.Clear();
                scripture.Display();
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;
                else
                    scripture.HideRandomWord();
            }
            Console.WriteLine("All words hidden. Goodbye!");

            // Reset word states for re-use
            scripture.ResetWordStates();
        }
    }
}
