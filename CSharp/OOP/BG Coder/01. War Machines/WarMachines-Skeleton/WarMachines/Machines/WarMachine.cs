namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;
    public abstract class WarMachine : IMachine
    {
        public const string WarMachineName = "- {0}";
        public const string WarMachineType = " *Type: {0}";
        public const string WarMachineHealth = " *Health: {0}";
        public const string WarMachineAttack = " *Attack: {0}";
        public const string WarMachineDefense = " *Defense: {0}";
        public const string WarMachineTarget = " *Targets: {0}";

        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        public WarMachine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }
        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Warmachine's pilot cannot be null");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Healthpoints cannot be negative");
                }

                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                if (this.GetType().Name == "Tank" && (this as Tank).DefenseMode)
                {
                    return this.attackPoints - 40;
                }
                return this.attackPoints;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Attackpoints cannot be negative");
                }

                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                if (this.GetType().Name == "Tank" && (this as Tank).DefenseMode)
                {
                    return this.defensePoints + 30;
                }
                return this.defensePoints;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Defense points cannot be negative");
                }

                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public void Attack(string target)
        {
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder();
            description.AppendLine(String.Format(WarMachineName, this.Name));
            description.AppendLine(String.Format(WarMachineType, this.GetType().Name));
            description.AppendLine(String.Format(WarMachineHealth, this.HealthPoints));
            description.AppendLine(String.Format(WarMachineAttack, this.AttackPoints));
            description.AppendLine(String.Format(WarMachineDefense, this.DefensePoints));
            string targetResult = "None";
            if (Targets.Count > 0)
            {
                targetResult = String.Empty;
                foreach (var target in Targets)
                {
                    targetResult = targetResult + target + ", ";
                }
                targetResult = targetResult.TrimEnd(new char[2] { ' ', ',' });
            }
            
            description.AppendLine(String.Format(WarMachineTarget, targetResult));
            return description.ToString().Trim();
        }
    }
}
