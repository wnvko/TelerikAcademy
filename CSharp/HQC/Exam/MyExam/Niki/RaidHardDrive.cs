namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class RaidHardDrive : HardDrive
    {
        private int numberOfHardDrives;
        private List<IHardDrive> hardDrives;

        public RaidHardDrive(int capacity, int numberOfHardDrives)
            : base(capacity)
        {
            this.numberOfHardDrives = numberOfHardDrives;
            this.hardDrives = new List<IHardDrive>();
        }

        public int Capacity
        {
            get
            {
                if (!this.hardDrives.Any())
                {
                    return 0;
                }

                return this.hardDrives.First().Capacity;
            }

            set
            {
                foreach (IHardDrive hardDrive in this.hardDrives)
                {
                    this.hardDrives.Capacity = value;
                }
            }
        }

        public override void SaveData(int address, string newData)
        {
            foreach (IHardDrive hardDrive in this.hardDrives)
            {
                hardDrive.SaveData(address, newData);
            }
        }

        public override string LoadData(int address)
        {
            if (!this.hardDrives.Any())
            {
                throw new OutOfMemoryException("No hard drive in the RAID array!");
            }

            return this.hardDrives.First().LoadData(address);
        }
    }
}
