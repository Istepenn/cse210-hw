using System;

// Example of abstraction in C# using classes

// Abstract class representing an animal
abstract class Animal
{
    // Abstract method indicating that animals make sounds
    public abstract string MakeSound();
}

// Concrete class representing a dog
class Dog : Animal
{
    // Implementation of MakeSound specific to a dog
    public override string MakeSound()
    {
        return "Woof!";
    }
}

// Concrete class representing a cat
class Cat : Animal
{
    // Implementation of MakeSound specific to a cat
    public override string MakeSound()
    {
        return "Meow!";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Usage of abstraction
        Dog dog = new Dog();
        Cat cat = new Cat();

        Console.WriteLine(dog.MakeSound()); // Output: Woof!
        Console.WriteLine(cat.MakeSound()); // Output: Meow!
    }
}
