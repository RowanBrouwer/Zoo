using System;
using System.Collections.Generic;
using System.Text;

namespace Dierentuin.Classes
{
    public abstract class Animal
    {
        public virtual string Name { get; set; }
        public virtual int energy { get; set; }
        public abstract int Feed();
        public abstract int UseEnergy();

    }
}
