
//using System;
//using System.Collections.Generic;
//using Computers;
//using Computers.Contracts;

//namespace Computers
//{
//    class Computer
//    {
//        public const int MinNumberToGues = 1;
//        public const int MaxNumberToGues = 10;
//        public const string WrongAnswer = "You didn't guess the number ";
//        public const string RightAnswer = "You win!";

//        readonly IBattery battery;

//        internal Computer(ICPU cpu, IRam ram, IHardDrive hardDrives, IVideoCard videoCard, IBattery battery)
//        {
//            Cpu = cpu;
//            Ram = ram;
//            HardDrives = hardDrives;
//            VideoCard = videoCard;
//            if (type != Computers.Type.LAPTOP && type != Computers.Type.PC)
//            {
//                VideoCard = new VideoCardMonochrome();
//            }

//            this.battery = battery;
//        }

//        ICPU Cpu { get; set; }

//        IRam Ram { get; set; }

//        IVideoCard VideoCard { get; set; }

//        IHardDrive HardDrives { get; set; }

//        internal void ChargeBattery(int percentage)
//        {
//            battery.Charge(percentage);

//            VideoCard.Draw(string.Format("Battery status: {0}", battery.PercentCharge));
//        }

//        internal void Process(int data)
//        {

//            Ram.SaveValue(data);



//            int value = Cpu.SquareNumber(this.Ram);

//            this.VideoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
//        }

//        public void Play(int guessNumber)
//        {
//            Cpu.GenerateRandomNumber(this.Ram, MinNumberToGues, MaxNumberToGues);
//            var number = Ram.LoadValue();
//            if (number != guessNumber)
//            {
//                VideoCard.Draw(WrongAnswer + number);
//            }
//            else
//            {
//                VideoCard.Draw(RightAnswer);
//            }
//        }
//    }
//}