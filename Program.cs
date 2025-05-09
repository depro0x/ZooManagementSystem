using System;
using System.Collections.Generic;

interface IFeedable {
    void Feed();
}

abstract class Animal : IFeedable {
    public string Name {get; set;}
    public int Age{get; set;}
    public string Species{get; set;}

    public Animal(string name, int age, string species) {
        Name = name;
        Age = age;
        Species = species;
    }

    public void Feed() {
        Console.WriteLine($"{Name} the {Species} is being fed.");
    }

    public virtual void DisplayInfo() {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Species: {Species}");
    }

    public abstract void MakeSound();
}

class Lion : Animal {
    public Lion(string name, int age) : base(name, age, "Lion") {}
    public override void MakeSound() {
        Console.WriteLine("Roarrrr!");
    }
}

class Cat : Animal {
    public Cat(string name, int age) : base(name, age, "Cat") {}
    public override void MakeSound() {
        Console.WriteLine("Meowwww!");
    }
}

class Elephant : Animal {
    public Elephant(string name, int age) : base(name, age, "Elephant") { }

    public override void MakeSound() {
        Console.WriteLine("Rrrrrrr!");
    }
}

class Monkey : Animal {
    public Monkey(string name, int age) : base(name, age, "Monkey") { }

    public override void MakeSound()
    {
        Console.WriteLine("Chhhiiiii!");
    }
}

class Zoo {
    private List<Animal> animals = new List<Animal>();
    private int totalVisitors = 0;

    public void AddAnimal(Animal animal) {
        animals.Add(animal);
        Console.WriteLine($"Added {animal.Name} the {animal.Species} to the zoo.");
    }
    
    public void RemoveAnimal(string name) {
        Animal found = animals.Find(a => a.Name.ToLower() == name.ToLower());
        if (found != null) {
            animals.Remove(found);
            Console.WriteLine($"Removed {found.Name} the {found.Species} from the zoo.");
        }
        else {
            Console.WriteLine("Animal not found.");
        }
    }

    public void ShowAllAnimals() {
        Console.WriteLine("\nZoo Animal List:");
        foreach (var animal in animals) {
            animal.DisplayInfo();
            animal.MakeSound();
        }
    }

    public void FeedAllAnimals() {
        Console.WriteLine("\nFeeding all animals:");
        foreach (var animal in animals) {
            animal.Feed();
        }
    }

    public void ShowAnimalCount() {
        Console.WriteLine($"\nTotal number of animals in zoo: {animals.Count}");
    }

    public void EnterVisitor() {
        totalVisitors++;
        Console.WriteLine("Visitor entered the zoo.");
    }

    public void ShowVisitorCount() {
        Console.WriteLine($"Total visitors today: {totalVisitors}");
    }
}

class Program {
    static void Main() {
        Zoo myZoo = new Zoo();
        bool exit = false;

        while (!exit) {
            Console.WriteLine("\n--- Zoo Management System ---");
            Console.WriteLine("1. Add Animal");
            Console.WriteLine("2. Remove Animal");
            Console.WriteLine("3. Show All Animals");
            Console.WriteLine("4. Feed All Animals");
            Console.WriteLine("5. Show Animal Count");
            Console.WriteLine("6. Enter Visitor");
            Console.WriteLine("7. Show Visitor Count");
            Console.WriteLine("8. Exit");
            Console.WriteLine("\nChoose an option: ");

            int choice = int.Parse(Console.ReadLine());
            switch(choice) {
                case 1:
                    Console.Write("Enter animal type (Lion/Elephant/Monkey/Cat): ");
                    string type = Console.ReadLine();
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter age: ");
                    int age = int.Parse(Console.ReadLine());

                    Animal animal = type.ToLower() switch
                    {
                        "lion" => new Lion(name, age),
                        "elephant" => new Elephant(name, age),
                        "monkey" => new Monkey(name, age),
                        "cat" => new Cat(name, age),
                        _ => null
                    };

                    if (animal != null)
                        myZoo.AddAnimal(animal);
                    else
                        Console.WriteLine("Invalid animal type.");
                    break;
                case 2:
                    Console.Write("Enter name of animal to remove: ");
                    string removeName = Console.ReadLine();
                    myZoo.RemoveAnimal(removeName);
                    break;
                case 3:
                    myZoo.ShowAllAnimals();
                    break;
                case 4:
                    myZoo.FeedAllAnimals();
                    break;
                case 5:
                    myZoo.ShowAnimalCount();
                    break;
                case 6:
                    myZoo.EnterVisitor();
                    break;
                case 7:
                    myZoo.ShowVisitorCount();
                    break;
                case 8:
                    exit = true;
                    Console.WriteLine("Exiting Zoo Management System...");
                    break;
                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }

        }
    }
}