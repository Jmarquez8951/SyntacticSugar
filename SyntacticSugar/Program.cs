using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntacticSugar
{
    class Program
    {
        static void Main(string[] args)
        {
            var predators = new List<string>();
            predators.Add("AntEater");
            predators.Add("Termites");

            var prey = new List<string>();
            prey.Add("Carrion");
            prey.Add("Sugar");

            var bug = new Bug("ant", "ant", predators, prey);

            Console.WriteLine(bug.FormalName);
            
            Console.WriteLine($"{bug.FormalName} likes to prey on {bug.PreyList()}");
            Console.WriteLine($"{bug.FormalName} hates {bug.PredatorList()}");
            
            Console.WriteLine(bug.Eat("Sugar"));
            Console.WriteLine(bug.Eat("plastic"));

        }
    }
    public class Bug
    {
        public string Name { get; } = "";
        public string Species { get; } = "";
        public List<string> Predators { get; } = new List<string>();
        public List<string> Prey { get; } = new List<string>();

        public string FormalName => $"{this.Name} the {Species}";
        
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        public string PreyList() => string.Join(",", this.Prey);

        public string PredatorList() => string.Join(",", this.Predators);

        public string Eat(string food) => Prey.Contains(food)
                                            ? $"{this.Name} ate the {food}."
                                            : $"{this.Name} is still hungry.";
    }
}
