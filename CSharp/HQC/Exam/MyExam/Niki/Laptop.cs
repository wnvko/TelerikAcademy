namespace Computers
{
    using Contracts;

    public class Laptop : IComputer
    {
        public const int MinNumberToGues = 1;
        public const int MaxNumberToGues = 10;
        public const string WrongAnswer = "You didn't guess the number ";
        public const string RightAnswer = "You win!";

        internal Laptop(ICPU cpu, IRam ram, IHardDrive hardDrives, IVideoCard videoCard, IBattery battery)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            this.Battery = battery;
        }

        public IBattery Battery { get; set; }

        public ICPU Cpu { get; set; }

        public IRam Ram { get; set; }

        public IVideoCard VideoCard { get; set; }

        public IHardDrive HardDrives { get; set; }

        public void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}", this.Battery.PercentCharge));
        }
    }
}
