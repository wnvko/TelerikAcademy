
namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using WarMachines.Interfaces;
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> warMachineList;

        public Pilot(string name)
        {
            this.Name = name;
            warMachineList = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pilot name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            machine.Pilot = this;
            warMachineList.Add(machine);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            string numberOfMachines = String.Empty;
            if (warMachineList.Count == 0)
            {
                numberOfMachines = " - no machines";
            }
            else if (warMachineList.Count == 1)
            {
                numberOfMachines = " - 1 machine";
            }
            else
            {
                numberOfMachines = " - " + warMachineList.Count + " machines";
            }
            numberOfMachines = this.Name + numberOfMachines;
            var sortedMachines = warMachineList.OrderBy(m => m.Name).OrderBy(m => m.HealthPoints);
            result.AppendLine(numberOfMachines);
            foreach (var machine in sortedMachines)
            {
                result.AppendLine(machine.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
