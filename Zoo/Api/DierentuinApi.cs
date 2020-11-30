using Dierentuin.Classes;
using DierenTuin.Core.Classes;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
