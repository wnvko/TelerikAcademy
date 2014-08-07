namespace Computers
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Computers
    {
        private PC pc;
        private Server server;
        private Laptop laptop;

        public void Start()
        {
            while (true)
            {
                var curentCommand = Console.ReadLine();
                if (curentCommand == null)
                {
                    break;
                }

                if (curentCommand.StartsWith("Exit"))
                {
                    break;
                }

                if (!curentCommand.Contains(" "))
                {
                    if (curentCommand == "HP")
                    {
                        this.pc = new PC(new Cpu32(2), new Ram(2), new HardDrive(500), new VideoCardColorful());
                        this.server = new Server(new Cpu32(4), new Ram(32), new RaidHardDrive(1000, 2));
                        this.laptop = new Laptop(new Cpu64(2), new Ram(4), new HardDrive(500), new VideoCardColorful(), new LaptopBattery());
                        continue;
                    }
                    else if (curentCommand == "Dell")
                    {
                        this.pc = new PC(new Cpu64(4), new Ram(8), new HardDrive(1000), new VideoCardColorful());
                        this.server = new Server(new Cpu64(8), new Ram(64), new RaidHardDrive(2000, 2));
                        this.laptop = new Laptop(new Cpu32(4), new Ram(8), new HardDrive(1000), new VideoCardColorful(), new LaptopBattery());
                        continue;
                    }
                    else if (curentCommand == "Lenovo")
                    {
                        this.pc = new PC(new Cpu64(2), new Ram(4), new HardDrive(20000), new VideoCardMonochrome());
                        this.server = new Server(new Cpu128(2), new Ram(8), new RaidHardDrive(500, 2));
                        this.laptop = new Laptop(new Cpu64(2), new Ram(16), new HardDrive(1000), new VideoCardColorful(), new LaptopBattery());
                        continue;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid manufacturer!");
                    }
                }

                var commandsArray = curentCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandsArray.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandName = commandsArray[0];
                var commandArgument = int.Parse(commandsArray[1]);

                if (commandName == "Charge")
                {
                    this.laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == "Process")
                {
                    this.server.Process(commandArgument);
                }
                else if (commandName == "Play")
                {
                    this.pc.Play(commandArgument);
                }
            }
        }
    }
}
