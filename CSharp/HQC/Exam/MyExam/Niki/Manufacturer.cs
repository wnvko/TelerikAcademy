using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers
{
    using Contracts;

    public class Manufacturer : IManufacturer
    {
        public IComputer CreateComputer(ICPU cpu, IRam ram, IHardDrive hardDrives, IVideoCard videoCard)
        {
            IComputer pc = new PC(cpu, ram, hardDrives, videoCard);
            return pc;
        }

        public IComputer CreateComputer(ICPU cpu, IRam ram, IHardDrive hardDrives, IVideoCard videoCard, IBattery battery)
        {
            IComputer laptop = new Laptop(cpu, ram, hardDrives, videoCard, battery);
            return laptop;
        }

        public IComputer CreateComputer(ICPU cpu, IRam ram, IHardDrive hardDrives)
        {
            IComputer server = new Server(cpu, ram, hardDrives);
            return server;
        }
    }
}
