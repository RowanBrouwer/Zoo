using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin.Classes
{
    public sealed class Monkey : Animal
    {
        int maxEnergy = 100;
        int foodUsage = 10;
        int energyUsage = 2;
        private string name;
        private int _energy;

        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public override int energy
        {
            get
            {
                return _energy;
            }
            set
            {
                _energy = value;
            }
        }

        public override Task<int> Feed()
        {
            if (energy >= maxEnergy)
            {
                energy = maxEnergy;
                return Task.FromResult<int>(energy);
            }
            else
            {
                energy = energy + 25;
                return Task.FromResult<int>(energy);
            }
        }

        public override Task<int> UseEnergy()
        {
            if (energy <= 0)
            {
                return Task.FromResult<int>(0);
            }
            else
            {
                int adjustedEnergy = energy - energyUsage;
                return Task.FromResult<int>(adjustedEnergy);
            }
        }
    }
}
