namespace Computers
{
    using System;
    using Contracts;

    public class Server : IComputer
    {
        internal Server(ICPU cpu, IRam ram, IHardDrive hardDrives)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = new VideoCardMonochrome();
        }

        public ICPU Cpu { get; set; }

        public IRam Ram { get; set; }

        public IVideoCard VideoCard { get; set; }

        public IHardDrive HardDrives { get; set; }

        internal void Process(int data)
        {
            this.Ram.SaveValue(data);
            int value = 0;

            try
            {
                value = this.Cpu.SquareNumber(this.Ram);
            }
            catch (ArgumentOutOfRangeException e)
            {
                this.VideoCard.Draw(e.Message);
                return;
            }

            this.VideoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
        }
    }
}