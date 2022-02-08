namespace Computers
{
    using Contracts;

    public class PC : IComputer
    {
        public const int MinNumberToGues = 1;
        public const int MaxNumberToGues = 10;
        public const string WrongAnswer = "You didn't guess the number ";
        public const string RightAnswer = "You win!";

        internal PC(ICPU cpu, IRam ram, IHardDrive hardDrives, IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
        }

        public ICPU Cpu { get; set; }

        public IRam Ram { get; set; }

        public IVideoCard VideoCard { get; set; }

        public IHardDrive HardDrives { get; set; }

        public void Play(int guessNumber)
        {
            this.Cpu.GenerateRandomNumber(this.Ram, MinNumberToGues, MaxNumberToGues);
            var number = this.Ram.LoadValue();
            if (number != guessNumber)
            {
                this.VideoCard.Draw(WrongAnswer + number);
            }
            else
            {
                this.VideoCard.Draw(RightAnswer);
            }
        }
    }
}
