namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    class Tank : WarMachine, ITank
    {
        public const double TankInitialHealthPoints = 100;
        public const bool TankInitialDefenseMode = true;
        public const string TankDefense = " *Defense: {0}";
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = TankInitialHealthPoints;
            this.DefenseMode = true;
        }
        public bool DefenseMode
        {
            get { return this.defenseMode; }
            private set { this.defenseMode = value; }
        }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder();
            description.AppendLine(base.ToString());
            description.Append(String.Format(TankDefense,(DefenseMode ? "ON":"OFF")));
            return description.ToString();
        }
    }
}
