namespace Computers.Contracts
{
    public interface IHardDrive
    {
        int Capacity { get; set; }

        void SaveData(int addr, string newData);

        string LoadData(int address);
    }
}
