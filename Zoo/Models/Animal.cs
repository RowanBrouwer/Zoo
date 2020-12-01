using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin.Classes
{
    public abstract class Animal
    {
        public virtual string Name { get; set; }
        public virtual int energy { get; set; }
        public abstract Task<int> Feed();
        public abstract Task<int> UseEnergy();

    }
}
