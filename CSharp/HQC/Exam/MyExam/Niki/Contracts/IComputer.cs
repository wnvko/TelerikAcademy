namespace Computers.Contracts
{
    public interface IComputer
    {
        ICPU Cpu { get; set; }

        IRam Ram { get; set; }

        IVideoCard VideoCard { get; set; }

        IHardDrive HardDrives { get; set; }
    }
}