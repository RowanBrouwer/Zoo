using Dierentuin.Classes;
using DierenTuin.Core.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DierenTuin.Core.Api
{
    public class DierentuinApi
    {
        public static void InitAnimals() => AllAnimals.InitAnimalsList();
        public static List<Animal> GetAnimals() => AllAnimals.Animals;


        public static void AddAnimal(Animal animal)
        {
            AllAnimals.Animals.Add(animal);
        }

        public static List<Animal> UpdateAnimals(List<Monkey> monkeys, List<Lion> lions, List<Elephant> elephants)
        {
            AllAnimals.InitAnimalsList();
            foreach (var m in monkeys)
            {
                AddAnimal(m);
            }
            foreach (var l in lions)
            {
                AddAnimal(l);
            }
            foreach (var e in elephants)
            {
                AddAnimal(e);
            }
            List<Animal> AnimalReturn = GetAnimals();
            return AnimalReturn;
        }
    }
}
