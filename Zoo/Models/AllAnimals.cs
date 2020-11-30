using Dierentuin.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DierenTuin.Core.Classes
{
    public class AllAnimals
    {
        public static void InitAnimalsList() => Animals = new List<Animal>();
        public static List<Animal> Animals { get; set; }
    }
}
