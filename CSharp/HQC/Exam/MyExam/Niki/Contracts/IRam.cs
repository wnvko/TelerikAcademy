namespace Computers.Contracts
{
    public interface IRam
    {
        void SaveValue(int value);

        int LoadValue();
    }
}
