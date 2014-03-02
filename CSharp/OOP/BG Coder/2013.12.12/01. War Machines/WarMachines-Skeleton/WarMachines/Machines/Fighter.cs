using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarMachines.Machines
{
    using WarMachines.Interfaces;
    public class Fighter : WarMachine, IFighter
    {
        public const double FighterInitialHealthPoints = 200;
        public const string FighterStealth = " *Stealth: {0}";
        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = FighterInitialHealthPoints;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
            private set { this.stealthMode = value; }
        }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder();
            description.AppendLine(base.ToString());
            description.Append(String.Format(FighterStealth, (StealthMode ? "ON" : "OFF")));
            return description.ToString();
        }

    }
}
