namespace Computers.Contracts
{
    public interface ICPU
    {
        int CoresCount { get; set; }

        int SquareNumber(IRam ram);

        void GenerateRandomNumber(IRam ram, int minValue, int maxValue);
    }
}
