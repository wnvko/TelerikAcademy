namespace Computers
{
    using System.Collections.Generic;
    using Contracts;

    public class HardDrive : IHardDrive
    {
        private Dictionary<int, string> data;

        public HardDrive(int capacity)
        {
            this.Capacity = capacity;
            this.data = new Dictionary<int, string>();
        }

        public int Capacity { get; set; }

        public virtual void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }

        public virtual string LoadData(int address)
        {
            return this.data[address];
        }
    }
}